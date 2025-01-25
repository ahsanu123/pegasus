<%@ Application Language="VB" %>
<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="System.Web.Routing" %>
<script RunAt="server">
	Private Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
		Dim defaultValues As New RouteValueDictionary()
		defaultValues.Add("description", "")
    
		Dim constraints As New RouteValueDictionary()
		'constraints.Add("httpMethod", "GET");
		constraints.Add("id", "\d+")
    
		Dim dataTokens As New RouteValueDictionary()
		dataTokens.Add("finalUrl", "~/articles.aspx")
    
		Using RouteTable.Routes.GetWriteLock()
			RouteTable.Routes.Add("ArticleRoute", New Route("articles/{id}/{description}", defaultValues, constraints, dataTokens, New ArticleRouteHandler()))
		End Using
	End Sub
</script>
