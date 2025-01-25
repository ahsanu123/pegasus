Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Microsoft.Security.Application

Partial Public Class Good
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Protected Sub SomeButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Results.Text = AntiXss.HtmlEncode(SomeText.Text)
        ClientScript.RegisterStartupScript(Me.[GetType](), "alert", String.Format("alert({0});", AntiXss.JavaScriptEncode(SomeText.Text)), True)
    End Sub
End Class