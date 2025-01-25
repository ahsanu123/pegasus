<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="System.Web.Routing" %>
<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        using (RouteTable.Routes.GetWriteLock())
        {
         //  RouteTable.Routes.Add("ArticleRoute", new Route("articles-eng/{id}/{description}", new PageRouteHandler("~/Articles.aspx")));
            
           Route articlesWithPageRoute = new Route("articles-eng/{id}/{description}/page{page}", new PageRouteHandler("~/Articles.aspx"));
           articlesWithPageRoute.Constraints = new RouteValueDictionary { { "id", @"\d{1,5}" }, { "page", @"\d{1,5}" } };
           articlesWithPageRoute.Defaults = new RouteValueDictionary { { "page", 1 } };

           RouteTable.Routes.Add("ArticleRoute", articlesWithPageRoute);
        }
    }
         
</script>
