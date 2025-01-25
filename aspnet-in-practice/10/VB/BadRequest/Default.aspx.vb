Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If String.IsNullOrEmpty(Request("ID")) Then
            Throw New HttpException(400, "Bad request")
        End If
    End Sub
End Class