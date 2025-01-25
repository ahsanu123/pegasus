Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class MessageTemplate
	Inherits System.Web.UI.Page

	Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		MyMessage.DataBind()
	End Sub
End Class