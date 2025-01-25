Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports System.Web
Imports System.Web.UI

<DefaultProperty("Text")>
 <ToolboxData("<{0}:FreeText runat=server text=""Insert your text here""></{0}:FreeText>")>
 Public Class FreeText
	Inherits Control
	<Bindable(True)>
	<Category("Appearance")>
	<DefaultValue("")>
	<Localizable(True)>
	Public Property Text() As String
		Get
			Return TryCast(ViewState("Text"), [String])
		End Get

		Set(ByVal value As String)
			ViewState("Text") = value
		End Set
	End Property

	Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
		writer.Write(Text)
	End Sub
End Class