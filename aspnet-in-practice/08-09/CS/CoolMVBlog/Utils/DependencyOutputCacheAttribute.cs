using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Caching;

namespace CoolMvcBlog.Utils
{
    public class DependencyOutputCacheAttribute : OutputCacheAttribute
    {
        public string ParameterName { get; set; }
        public string BasePrefix { get; set; }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            
            string key = string.IsNullOrEmpty(BasePrefix) ? 
                filterContext.RouteData.Values["action"].ToString() + "_" +
                filterContext.RouteData.Values["controller"].ToString() : BasePrefix;
            if (!string.IsNullOrEmpty(ParameterName))
                key += filterContext.RouteData.Values[ParameterName];
            
            filterContext.HttpContext.Cache.Insert(key, key, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration);
            filterContext.HttpContext.Response.AddCacheItemDependency(key);
        }
    }

    public class RemoveCachedAttribute : ActionFilterAttribute
    {
        public string ParameterName { get; set; }
        public string BasePrefix { get; set; }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);

            string key = string.IsNullOrEmpty(BasePrefix) ?
                filterContext.RouteData.Values["action"].ToString() + "_" +
                filterContext.RouteData.Values["controller"].ToString() : BasePrefix;

            if (!string.IsNullOrEmpty(ParameterName))
                key += filterContext.RouteData.Values[ParameterName];

            filterContext.HttpContext.Cache.Remove(key);
        }
    }
}