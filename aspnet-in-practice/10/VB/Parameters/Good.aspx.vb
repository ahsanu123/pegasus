Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class Good
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim id As Integer
        If Integer.TryParse(Request.QueryString("ID"), id) Then
            ' parameter is ok and the variable initialized


        End If
    End Sub
End Class