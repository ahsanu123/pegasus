Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Configuration.Provider
Imports System.Configuration
Imports System.Data
Imports System.Globalization

Namespace CustomerProviders

	Friend NotInheritable Class Utilities
		Private Sub New()
		End Sub
		Friend Shared Function FormatDateTimeForDbType(ByVal value As DateTime) As Object
			Return If((value.Year <= 1754), DirectCast(DBNull.Value, Object), DirectCast(value.ToString(DateTimeFormatInfo.InvariantInfo), Object))
		End Function

		Friend Shared Function ConvertFromCLRTypeToSqlDbType(ByVal propType As Type) As SqlDbType
			If propType.Equals(GetType(String)) Then
				Return SqlDbType.VarChar
			ElseIf propType.Equals(GetType(Int16)) OrElse propType.Equals(GetType(Int32)) Then
				Return SqlDbType.Int
			ElseIf propType.Equals(GetType(DateTime)) OrElse propType.Equals(GetType(System.Nullable(Of DateTime))) Then
				Return SqlDbType.DateTime
			ElseIf propType.Equals(GetType([Decimal])) Then
				Return SqlDbType.[Decimal]
			ElseIf propType.Equals(GetType(Double)) OrElse propType.Equals(GetType(Single)) Then
				Return SqlDbType.Float
			ElseIf propType.Equals(GetType(Boolean)) Then
				Return SqlDbType.Bit
			End If

			' add others if needed
			Return SqlDbType.[Variant]
		End Function

		Friend Shared Sub HasValidName(ByVal name As String)
			Dim legalChars As String = "_@#$"
			For i As Integer = 0 To name.Length - 1
				If Not [Char].IsLetterOrDigit(name(i)) AndAlso legalChars.IndexOf(name(i)) = -1 Then
					Throw New ProviderException("Table and column names cannot contain: " & name(i))
				End If
			Next
		End Sub
	End Class

End Namespace