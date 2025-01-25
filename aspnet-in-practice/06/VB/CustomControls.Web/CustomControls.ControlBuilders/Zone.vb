Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Web.UI
Imports System.Collections
Imports System.Web.UI.WebControls

<ControlBuilder(GetType(ZoneBuilder))>
 <ParseChildren(False)>
Public Class Zone
	Inherits CMSPartBase
	Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)
		For i As Integer = 0 To Me.Controls.Count - 1
			Controls(i).RenderControl(writer)
		Next
	End Sub

	Protected Overrides ReadOnly Property TagKey() As HtmlTextWriterTag
		Get
			Return HtmlTextWriterTag.Div
		End Get
	End Property
End Class