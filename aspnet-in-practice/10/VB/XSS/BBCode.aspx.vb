Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class BBCode
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Protected Sub SomeButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim text As String = SomeText.Text
        text = SecurityUtility.RemoveHtml(text)
        text = SecurityUtility.BBCode(text)
        Results.Text = text
    End Sub
End Class