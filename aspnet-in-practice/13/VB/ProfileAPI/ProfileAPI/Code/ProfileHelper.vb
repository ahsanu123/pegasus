Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Profile

Public Class ProfileHelper
	Public Shared Function GetFirstName() As String
		Return DirectCast(HttpContext.Current.Profile, MyProfile).FirstName
	End Function
End Class
