Imports System.Web.Routing

Partial Public Class Articles
	Inherits Page
	Implements IArticlePage

	Protected Property Id() As Integer Implements IArticlePage.Id
	Protected Property Description() As String Implements IArticlePage.Description

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Id = Convert.ToInt32(Page.RouteData.Values("id"))
		Description = TryCast(Page.RouteData.Values("description"), String)

		Dim url As String = Page.GetRouteUrl("ArticleRoute",
		   New RouteValueDictionary() From {
		   {"Id", "5"},
		   {"Description", "Test-URL"}})

		RoutedLink.NavigateUrl = url
	End Sub

End Class