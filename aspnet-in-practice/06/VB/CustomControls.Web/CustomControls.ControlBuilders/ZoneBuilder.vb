Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Web.UI
Imports System.Collections

Public Class ZoneBuilder
	Inherits ControlBuilder
	Public Overrides Function GetChildControlType(ByVal tagName As String, ByVal attribs As IDictionary) As Type
		' more options here
		If tagName.Equals("articles", StringComparison.InvariantCultureIgnoreCase) Then
			Return GetType(ArticleView)
		ElseIf tagName.Equals("box", StringComparison.InvariantCultureIgnoreCase) Then
			Return GetType(Box)
		End If

		Return Nothing
	End Function
End Class