Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

<ParseChildren(True)>
Public Class Message
	Inherits Control
	Implements INamingContainer

	<TemplateContainer(GetType(MessageItem)), PersistenceMode(PersistenceMode.InnerProperty), DefaultValue(GetType(ITemplate), "")> _
	Public Property ItemTemplate() As ITemplate

	Public Property Text() As String
		Get
			Return TryCast(ViewState("Text"), String)
		End Get
		Set(ByVal value As String)
			ViewState("Text") = value
		End Set
	End Property

	Protected Overrides Sub CreateChildControls()
		If ItemTemplate IsNot Nothing Then
			Dim template As New MessageItem(Me)
			ItemTemplate.InstantiateIn(template)
			Me.Controls.Clear()
			Me.Controls.Add(template)
		Else
			Controls.Add(New LiteralControl(Text))
		End If
	End Sub

	Protected Overrides Sub OnDataBinding(ByVal e As EventArgs)
		EnsureChildControls()
		MyBase.OnDataBinding(e)
	End Sub
End Class