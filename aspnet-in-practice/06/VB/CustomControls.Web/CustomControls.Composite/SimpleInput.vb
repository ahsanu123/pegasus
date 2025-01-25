Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel


<DefaultEvent("SelectedValueChanged")>
Public Class SimpleInput
	Inherits Control
	Implements IPostBackDataHandler
	Public Property Text() As String
		Get
			Return TryCast(ViewState("Text"), String)
		End Get
		Set(ByVal value As String)
			ViewState("Text") = value
		End Set
	End Property

	Public Function LoadPostData(ByVal postDataKey As String, ByVal postCollection As System.Collections.Specialized.NameValueCollection) As Boolean Implements IPostBackDataHandler.LoadPostData
		If Not postCollection(postDataKey).Equals(Text, StringComparison.InvariantCultureIgnoreCase) Then
			Text = postCollection(postDataKey)
			Return True
		End If
		Return False
	End Function

	Public Sub RaisePostDataChangedEvent() Implements IPostBackDataHandler.RaisePostDataChangedEvent
		RaiseEvent SelectedValueChanged(Me, New EventArgs())
	End Sub

	Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
		writer.WriteBeginTag("input")
		writer.WriteAttribute("value", Text)
		writer.WriteAttribute("id", ClientID)
		writer.WriteEndTag("input")
	End Sub

	Public Event SelectedValueChanged As EventHandler

	Protected Sub OnSelectedValueChanged(ByVal e As EventArgs)
		RaiseEvent SelectedValueChanged(Me, e)
	End Sub
End Class
