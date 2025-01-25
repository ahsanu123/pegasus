Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Web.UI

Public Class ArticleView
	Inherits CMSPartBase
	Public Property Category() As String

	Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
		writer.Write("<h1>" & Title & "</h1>")
		writer.Write("<p>This is a list of " & PageSize.ToString() & " articles in " & Category & ".</p>")
	End Sub
End Class