Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Web.UI

' if we inherit from Zone, we can encapsulate other elements as in the main control
Public Class Box
	Inherits Zone
	Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
		If Not String.IsNullOrEmpty(Title) Then
			writer.WriteBeginTag("h2")
			writer.Write(">")
			writer.Write(Title)
			writer.WriteEndTag("h2")
		End If

		MyBase.Render(writer)
	End Sub
End Class