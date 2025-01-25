using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace CoolMvcBlog.Utils.Security
{
    public static class Helpers
    {
        public static HtmlString Login(this HtmlHelper html, string controller, string loginAction, string logoutAction)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
                return WelcomeMessage(html, logoutAction, controller);
            else
                return LoginInput(html, loginAction, controller);
        }

        private static HtmlString WelcomeMessage(HtmlHelper html, string logoutAction, string controller)
        {
            return new HtmlString(string.Format("Welcome {0} :: {1}",
                HttpContext.Current.User.Identity.Name,
                html.ActionLink("Logout", logoutAction, controller)));
        }

        private static HtmlString LoginInput(HtmlHelper html, string loginAction, string controller)
        {
            TagBuilder form = new TagBuilder("form");
            form.MergeAttribute("action", UrlHelper.GenerateUrl(null, loginAction, controller, new RouteValueDictionary(), html.RouteCollection, html.ViewContext.RequestContext, true));
            form.MergeAttribute("method", "post");
            form.InnerHtml = string.Format("User: {0} Pass: {1} {2}",
                html.TextBox("username"),
                html.Password("password"),
                "<input type=\"submit\" value=\"Login\" />"
                );

            return new HtmlString(form.ToString());
        }
    }
}