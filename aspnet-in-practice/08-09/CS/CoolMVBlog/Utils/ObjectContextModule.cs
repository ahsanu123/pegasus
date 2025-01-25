using System.Web;
using CoolMvcBlog.Models;
using System;
namespace CoolMvcBlog.Utils
{
    public class ObjectContextModule : IHttpModule
    {
        private const string sessionKey = "objectcontext.current";

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.PostAcquireRequestState += (s, e) =>
                {
                    if (HttpContext.Current != null && HttpContext.Current.Session != null)
                        CurrentContext = new BlogModelContainer();
                };

            context.ReleaseRequestState += (s, e) =>
                {
                    if (HttpContext.Current != null && HttpContext.Current.Session != null)
                    {
                        CurrentContext.Dispose();
                        CurrentContext = null;
                    }
                };
        }

        public static BlogModelContainer CurrentContext
        {
            get 
            {
                return (BlogModelContainer) HttpContext.Current.Session[sessionKey];
            }
            private set 
            {
                HttpContext.Current.Session[sessionKey] = value;
            }
        }

        //private stati void checkContext()
        //{
        //    if (HttpContext.Current == null ||
        //        HttpContext.Current.Session == null)
        //    {
        //        throw new InvalidOperationException("Session not found while retrieving ObjectContext");
        //    }
        //}
    }
}