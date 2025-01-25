<%@ Application Language="VB" %>
<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="System.Web.Routing" %>
<script RunAt="server">

Private Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
		Using RouteTable.Routes.GetWriteLock()
			' RouteTable.Routes.Add("ArticleRoute", new Route("articles-eng/{id}/{description}", new PageRouteHandler("~/Articles.aspx")));
        
			Dim articlesWithPageRoute As New Route("articles-eng/{id}/{description}/page{page}", New PageRouteHandler("~/Articles.aspx"))

			articlesWithPageRoute.Constraints = New RouteValueDictionary From {{"id", "\d{1,5}"}, {"page", "\d{1,5}"}}
			articlesWithPageRoute.Defaults = New RouteValueDictionary From {{"page", 1}}
        
			RouteTable.Routes.Add("ArticleRoute", articlesWithPageRoute)
		End Using
	End Sub
         
</script>
