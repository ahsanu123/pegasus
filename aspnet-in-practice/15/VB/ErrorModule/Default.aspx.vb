Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
    Inherits System.Web.UI.Page
    Protected Sub MyButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim results As Integer = 10 / Convert.ToInt32(ErrorBox.Text)
    End Sub
End Class