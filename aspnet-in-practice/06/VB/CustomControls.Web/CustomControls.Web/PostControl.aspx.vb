Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports CustomControls.Composite

Partial Public Class PostControlPage
	Inherits System.Web.UI.Page

	Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		If Not IsPostBack Then
			DateView.Value = DateTime.Now
		End If
	End Sub

	Protected Sub GetValueFromPostBack(ByVal sender As Object, ByVal e As EventArgs)
		Feedback.Text = "Sent from PostBack: " + DirectCast(sender, PostControl).Value
	End Sub
End Class