using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Routing;
using System.Web.UI;

public class ArticleRouteHandler : IRouteHandler 
{ 
  IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext) 
  { 
    string realUrl = 
              requestContext.RouteData.DataTokens["finalUrl"].ToString();
    string virtualPath = VirtualPathUtility.ToAbsolute(realUrl);

    IArticlePage pp = BuildManager.CreateInstanceFromVirtualPath(
        virtualPath,
        typeof(Page)) as IArticlePage;

    pp.Id = Convert.ToInt32(requestContext.RouteData.Values["id"]);
    return pp; 
  }
}
