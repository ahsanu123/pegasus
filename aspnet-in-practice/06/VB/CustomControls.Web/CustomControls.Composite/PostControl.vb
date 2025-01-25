Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Web.UI.WebControls
Imports System.Web.UI

Public Class PostControl
	Inherits WebControl
	Implements IPostBackEventHandler
	Public Property Value() As DateTime
		Get
			Return CType(If(ViewState("Value"), DateTime.MinValue), DateTime)
		End Get
		Set(ByVal value As DateTime)
			ViewState("Value") = value
		End Set
	End Property

	Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)
		Dim postBackLink As String = Page.ClientScript.GetPostBackClientHyperlink(Me, Value.ToString(), True)
		Dim link As New HyperLink()
		link.NavigateUrl = postBackLink
		link.Text = "Test PostBack"
		link.RenderControl(writer)
	End Sub

	Public Sub RaisePostBackEvent(ByVal eventArgument As String) Implements IPostBackEventHandler.RaisePostBackEvent
		' get the value from post back - your multiple postback params logic here
		Value = DateTime.Parse(eventArgument)

		' fire the event
		OnValueChanged(EventArgs.Empty)
	End Sub

	Public Event ValueChanged As EventHandler

	Protected Sub OnValueChanged(ByVal e As EventArgs)
		RaiseEvent ValueChanged(Me, e)
	End Sub

End Class

