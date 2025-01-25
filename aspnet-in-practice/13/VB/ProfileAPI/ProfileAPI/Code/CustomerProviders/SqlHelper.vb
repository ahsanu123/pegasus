Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.Common

Namespace CustomerProviders
	Friend NotInheritable Class SqlHelper
		Private Sub New()
		End Sub
		Friend Shared Sub ExecuteNonQuery(ByVal sqlConnectionString As String, ByVal commandType As CommandType, ByVal query As String, ByVal sqlParameter As SqlParameter())
			Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings(sqlConnectionString).ConnectionString)
				conn.Open()

				Using cmd As New SqlCommand(query, conn)
					cmd.CommandType = commandType
					If sqlParameter IsNot Nothing AndAlso sqlParameter.Length > 0 Then
						cmd.Parameters.AddRange(sqlParameter)
					End If

					cmd.ExecuteNonQuery()
				End Using
			End Using
		End Sub

		Friend Shared Function ExecuteReader(ByVal sqlConnectionString As String, ByVal commandType As CommandType, ByVal query As String, ByVal sqlParameter As SqlParameter()) As SqlDataReader
			Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings(sqlConnectionString).ConnectionString)
			conn.Open()

			Dim cmd As New SqlCommand(query, conn)

			cmd.CommandType = commandType
			If sqlParameter IsNot Nothing AndAlso sqlParameter.Length > 0 Then
				cmd.Parameters.AddRange(sqlParameter)
			End If

			Return cmd.ExecuteReader(CommandBehavior.CloseConnection)

		End Function
	End Class
End Namespace