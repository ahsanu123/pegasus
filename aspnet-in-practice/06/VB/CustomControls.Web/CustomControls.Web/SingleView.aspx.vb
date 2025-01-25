Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class SingleView
	Inherits System.Web.UI.Page

	Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		' test the EmptyTemplate
		'AuthorView.DataSource = Nothing

		' test the ItemTemplate
		AuthorView.DataSource = New Author() With {.FirstName = "Daniele", .LastName = "Bochicchio"}

		AuthorView.DataBind()
	End Sub
End Class


Public Class Author
	Public Property FirstName As String
	Public Property LastName As String
End Class