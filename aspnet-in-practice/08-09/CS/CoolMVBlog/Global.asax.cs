using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CoolMvcBlog.Utils;
using CoolMvcBlog.Models;
using System.Data.Objects.DataClasses;

namespace CoolMvcBlog
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "PostsByMonth",
                "Posts/{month}/{year}",
                new { controller = "Posts", action = "Search" });

            routes.MapSEORoute(
                "Post",
                "Post/{id}/{uniqueName}",
                new { controller = "Home", action = "Post" }
            );

            routes.MapSEORoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            DataAnnotationsModelValidatorProvider
                .RegisterAdapter(typeof(EmailAddressAttribute), typeof(EmailAddressValidator));

            ModelBinders.Binders[typeof(Post)] =
                new PostModelBinder();
            ModelBinders.Binders[typeof(EntityCollection<Category>)] =
                new CategoriesModelBinder();
        }
    }
}