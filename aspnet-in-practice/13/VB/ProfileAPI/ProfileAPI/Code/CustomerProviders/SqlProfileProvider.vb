Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Configuration.Provider
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Profile
Imports System.Web
Imports System.Security.Principal
Imports System.Text
Imports System.Globalization
Imports System.Data.Common

Namespace CustomerProviders
	Public NotInheritable Class SqlProfileProvider
		Inherits ProfileProvider
		Private _applicationName As String
		Private _sqlConnectionString As String
		Private _tableName As String = "Profiles"

		Public Overrides Property ApplicationName() As String
			Get
				Return _applicationName
			End Get
			Set(ByVal value As String)
				_applicationName = value
			End Set
		End Property

		Public Overrides Sub Initialize(ByVal name As String, ByVal config As NameValueCollection)
			' get the config
			If config Is Nothing Then
				Throw New ArgumentNullException("config is null")
			End If

			MyBase.Initialize(name, config)

			' get the application name
			_applicationName = config("applicationName")
			_sqlConnectionString = config("connectionStringName")
			If config("tableName") IsNot Nothing Then
				_tableName = config("tableName")
			End If

			' check for a connection string
			If _sqlConnectionString Is Nothing OrElse _sqlConnectionString.Length < 1 Then
				Throw New ProviderException("The ConnectionString must be specified.")
			End If

			' remove recognized attributes
			config.Remove("tableName")
			config.Remove("commandTimeout")
			config.Remove("connectionStringName")
			config.Remove("applicationName")
			config.Remove("description")

			' throw if unrecognized attributes are specified
			If config.Count > 0 Then
				Dim attribUnrecognized As String = config.GetKey(0)
				If Not [String].IsNullOrEmpty(attribUnrecognized) Then
					Throw New ProviderException([String].Format("The attribute {0} specified in web.config is not allowed. Please remove it.", attribUnrecognized))
				End If
			End If
		End Sub

		Public Overrides Function GetPropertyValues(ByVal context As SettingsContext, ByVal collection As SettingsPropertyCollection) As SettingsPropertyValueCollection
			If collection Is Nothing OrElse collection.Count < 1 OrElse context Is Nothing Then
				Return Nothing
			End If

			Dim username As String = GetUsername(context)

			Dim itemKey As String = String.Concat("profile-", username)

			If HttpContext.Current.Items(itemKey) Is Nothing Then
				' this will ensure the data will be get only time per request
				HttpContext.Current.Items(itemKey) = GetProfileData(collection, username)
			End If

			Return TryCast(HttpContext.Current.Items(itemKey), SettingsPropertyValueCollection)
		End Function

		Private Shared Function GetUsername(ByVal context As SettingsContext) As String
			Dim user As IPrincipal = HttpContext.Current.User

			Dim username As String = DirectCast(context("UserName"), String)

			' get the username
			If [String].IsNullOrEmpty(username) AndAlso user.Identity.IsAuthenticated Then
				username = user.Identity.Name
			End If

			' otherwise, the user is anonymous - unsupported
			If [String].IsNullOrEmpty(username) Then
				Throw New NotSupportedException("Anonymous profiles are not supported")
			End If

			Return username
		End Function

		Public Overrides Sub SetPropertyValues(ByVal context As SettingsContext, ByVal collection As SettingsPropertyValueCollection)
			Dim username As String = GetUsername(context)
			Dim userIsAuthenticated As Boolean = CBool(context("IsAuthenticated"))

			If username Is Nothing OrElse username.Length < 1 OrElse collection.Count < 1 Then
				Return
			End If

			Try
				' let's start to compose the query
				Dim sqlCommand As StringBuilder = New StringBuilder("IF EXISTS (SELECT 1 FROM ").Append(_tableName)
				sqlCommand.Append(" WHERE Username = @Username) ")

				' parameters used in the query
				Dim parameters As New List(Of SqlParameter)()
				parameters.Add(New SqlParameter("@Username", username))

				Dim columnsQuery As New StringBuilder()
				Dim valuesQuery As New StringBuilder()
				Dim setQuery As New StringBuilder()
				Dim param As SqlParameter
				Dim dtParam As DateTime

				Dim anyItemsToSave As Boolean = False
				Dim count As Integer = 0

				' check for modified items
				For Each pp As SettingsPropertyValue In collection
					If pp.IsDirty AndAlso Not pp.[Property].IsReadOnly Then
						If Not userIsAuthenticated Then
							Dim allowAnonymous As Boolean = CBool(pp.[Property].Attributes("AllowAnonymous"))
							If Not allowAnonymous Then
								Continue For
							End If
						End If
						anyItemsToSave = True

						Dim columnName As String = pp.Name
						Dim dbType__1 As SqlDbType = Utilities.ConvertFromCLRTypeToSqlDbType(pp.[Property].PropertyType)

						Dim value As Object = Nothing

						' null check
						If pp.Deserialized AndAlso pp.PropertyValue Is Nothing Then
							value = DBNull.Value
						Else
							value = pp.PropertyValue
						End If

						columnsQuery.Append(", ")
						valuesQuery.Append(", ")
						columnsQuery.Append(columnName)
						Dim valueParam As String = "@Value" & count
						valuesQuery.Append(valueParam)

						param = New SqlParameter(valueParam, dbType__1)

						If param.DbType = DbType.DateTime Then
							If DateTime.TryParse(value.ToString(), dtParam) Then
								param.Value = Utilities.FormatDateTimeForDbType(dtParam)
							Else
								param.Value = DBNull.Value
							End If
						Else
							param.Value = value
						End If

						parameters.Add(param)

						If count > 0 Then
							setQuery.Append(",")
						End If

						setQuery.Append(columnName)
						setQuery.Append("=")
						setQuery.Append(valueParam)

						count += 1
					End If
				Next

				If Not anyItemsToSave Then
					Return
				End If

				' continue to build the query
				sqlCommand.Append("BEGIN UPDATE ").Append(_tableName).Append(" SET ").Append(setQuery.ToString())
				sqlCommand.Append(" WHERE Username = @Username")

				sqlCommand.Append(" END ELSE BEGIN INSERT ").Append(_tableName)
				sqlCommand.Append(" (Username").Append(columnsQuery.ToString())
				sqlCommand.Append(") VALUES (@Username").Append(valuesQuery.ToString()).Append(") END")

				' esecuzione della query
				SqlHelper.ExecuteNonQuery(_sqlConnectionString, CommandType.Text, sqlCommand.ToString(), parameters.ToArray())
			Catch ex As Exception
				Throw New ProviderException("Provider error. See inner exception", ex)
			End Try
		End Sub

		Private Function GetProfileData(ByVal properties As SettingsPropertyCollection, ByVal username As String) As SettingsPropertyValueCollection
			Dim values As New SettingsPropertyValueCollection()

			Dim commandText As New StringBuilder("SELECT t.Username")
			Dim columns As New List(Of SettingsPropertyValue)()
			Dim columnCount As Integer = 0

			' build the query to include the properties
			For Each prop As SettingsProperty In properties
				Dim value As New SettingsPropertyValue(prop)
				values.Add(value)
				columns.Add(value)

				commandText.Append(", ")
				commandText.Append("t." + prop.Name)

				columnCount += 1
			Next

			commandText.Append(" FROM " & _tableName & " t WHERE ")
			commandText.Append("t.UserName = @Username")

			Dim param As New SqlParameter("@Username", username)

			Using reader As SqlDataReader = SqlHelper.ExecuteReader(_sqlConnectionString, CommandType.Text, commandText.ToString(), New SqlParameter() {param})
				If reader.Read() Then
					For i As Integer = 0 To columns.Count - 1
						Dim val As Object = reader.GetValue(i + 1)

						' null check
						If Not (val Is Nothing OrElse TypeOf val Is DBNull) Then
							columns(i).PropertyValue = val
							columns(i).IsDirty = False
							columns(i).Deserialized = True
						End If
					Next
				End If
			End Using

			Return values
		End Function

#Region "Not implemented"
		Public Overrides Function DeleteInactiveProfiles(ByVal authenticationOption As ProfileAuthenticationOption, ByVal userInactiveSinceDate As DateTime) As Integer
			Throw New NotSupportedException("The method or operation is not supported.")
		End Function

		Public Overrides Function DeleteProfiles(ByVal usernames As String()) As Integer
			Throw New NotSupportedException("The method or operation is not supported.")
		End Function

		Public Overrides Function DeleteProfiles(ByVal profiles As ProfileInfoCollection) As Integer
			Throw New NotSupportedException("The method or operation is not supported.")
		End Function

		Public Overrides Function FindInactiveProfilesByUserName(ByVal authenticationOption As System.Web.Profile.ProfileAuthenticationOption, ByVal usernameToMatch As String, ByVal userInactiveSinceDate As Date, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As System.Web.Profile.ProfileInfoCollection
			Throw New NotSupportedException("The method or operation is not supported.")
		End Function

		Public Overrides Function GetNumberOfInactiveProfiles(ByVal authenticationOption As ProfileAuthenticationOption, ByVal userInactiveSinceDate As DateTime) As Integer
			Throw New NotSupportedException("The method or operation is not supported.")
		End Function

		Public Overrides Function GetAllInactiveProfiles(ByVal authenticationOption As System.Web.Profile.ProfileAuthenticationOption, ByVal userInactiveSinceDate As Date, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As System.Web.Profile.ProfileInfoCollection
			Throw New NotSupportedException("The method or operation is not implemented.")
		End Function

		Public Overrides Function FindProfilesByUserName(ByVal authenticationOption As System.Web.Profile.ProfileAuthenticationOption, ByVal usernameToMatch As String, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As System.Web.Profile.ProfileInfoCollection
			Throw New NotSupportedException("The method or operation is not implemented.")
		End Function

		Public Overrides Function GetAllProfiles(ByVal authenticationOption As System.Web.Profile.ProfileAuthenticationOption, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As System.Web.Profile.ProfileInfoCollection
			Throw New NotSupportedException("The method or operation is not implemented.")
		End Function

		Private Function GetProfiles(ByVal usernameToMatch As String, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByVal totalRecords As Integer) As ProfileInfoCollection
			Throw New NotSupportedException("The method or operation is not implemented.")
		End Function
#End Region

	End Class

End Namespace