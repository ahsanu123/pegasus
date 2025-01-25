<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="System.Web.Routing" %>
<script RunAt="server">

	void Application_Start(object sender, EventArgs e)
	{
		RouteValueDictionary defaultValues = new RouteValueDictionary();
		defaultValues.Add("description", "");

		RouteValueDictionary constraints = new RouteValueDictionary();
		//constraints.Add("httpMethod", "GET");
		constraints.Add("id", @"\d+");

		RouteValueDictionary dataTokens = new RouteValueDictionary();
		dataTokens.Add("finalUrl", "~/articles.aspx");

		using (RouteTable.Routes.GetWriteLock())
			RouteTable.Routes.Add("ArticleRoute", new Route("articles/{id}/{description}",
			  defaultValues, constraints, dataTokens, new ArticleRouteHandler()));
	}    
</script>
