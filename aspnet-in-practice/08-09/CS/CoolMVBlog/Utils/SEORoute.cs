﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace CoolMvcBlog.Utils
{
    public class SEORoute : Route
    {
        public SEORoute(string url, IRouteHandler routeHandler)
			: base(url, routeHandler) { }
		public SEORoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
			: base(url, defaults, routeHandler) { }
		public SEORoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler)
			: base(url, defaults, constraints, routeHandler) { }
        public SEORoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler)
			: base(url, defaults, constraints, dataTokens, routeHandler) { }

		public override VirtualPathData GetVirtualPath(
            RequestContext requestContext, RouteValueDictionary values)
		{
			VirtualPathData path = base.GetVirtualPath(requestContext, values);
            
            if (path != null)
            {
                path.VirtualPath = path.VirtualPath.AppendTrailingSlash();
            }

			return path;
		}
    }
}