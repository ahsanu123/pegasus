using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;

namespace CoolMvcBlog.Utils
{
    public static class RouteHelpers
    {
        public static string AppendTrailingSlash(this string url)
        {
            int indexOfQueryString = url.IndexOf("?");
            if (indexOfQueryString != -1)
            {
                url = string.Concat(
                    VirtualPathUtility.AppendTrailingSlash(url.Substring(0, indexOfQueryString)),
                    url.Substring(indexOfQueryString));
            }
            else
            {
                url = VirtualPathUtility.AppendTrailingSlash(url);
            }

            return url;
        }

        public static string GetExtension(this string url)
        {
            int indexOfQueryString = url.IndexOf("?");
            if (indexOfQueryString != -1)
            {
                url = url.Substring(0, indexOfQueryString);
            }

            // url is domain name
            if (url.ToLower().StartsWith("http://") &&
                url.Substring(7).IndexOf("/") == -1)
                return string.Empty;

            return VirtualPathUtility.GetExtension(url);
        }

        public static Route MapSEORoute(this RouteCollection routes, string name, string url, object defaults)
        {
            return MapSEORoute(routes, name, url, defaults, null);
        }

        public static Route MapSEORoute(this RouteCollection routes, string name, string url, object defaults, object constraints)
        {
            var route = new SEORoute(
                url, new RouteValueDictionary(defaults), 
                new RouteValueDictionary(constraints), 
                new MvcRouteHandler());

            routes.Add(name, route);

            return route;
        }
    }
}