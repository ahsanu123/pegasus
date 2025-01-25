Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security

Partial Public Class Login
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        FormsAuthentication.RedirectFromLoginPage("username", False)
    End Sub
End Class