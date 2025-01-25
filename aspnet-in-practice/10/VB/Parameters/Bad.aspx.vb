Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class Bad
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        ' hey, look at me, I'm a comment! :)
        Dim id As Integer = Convert.ToInt32(Request.QueryString("ID"))
    End Sub
End Class