Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security

Public Partial Class Login
	Inherits System.Web.UI.Page
	Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		FormsAuthentication.RedirectFromLoginPage("username", True)
	End Sub
End Class
