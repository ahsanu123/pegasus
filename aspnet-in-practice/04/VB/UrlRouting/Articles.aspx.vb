Partial Public Class Articles
	Inherits Page
	Implements IArticlePage

	Protected Property Id() As Integer Implements IArticlePage.Id
	Protected Property Description() As String Implements IArticlePage.Description

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		ID = Convert.ToInt32(Page.RouteData.Values("id"))
		Description = TryCast(Page.RouteData.Values("description"), String)
	End Sub

End Class