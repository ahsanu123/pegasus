using System.Collections.Generic;

namespace WingtipToys.Routes
{
    public static class RouteNames
    {
        public const string AboutPage = "about-page";
        public const string ContactPage = "contact-page";
        public const string ManagementPage = "management-page";
        public const string ErrorPage = "error-page";
    }

    public static class PhysicalPath
    {
        public const string AboutAspx = "~/Pages/About.aspx";
        public const string ContactAspx = "~/Pages/Contact.aspx";
        public const string ManagementAspx = "~/Pages/Management.aspx";
        public const string ErrorAspx = "~/Pages/ErrorPage.aspx";
    }

    public static class ApplicationRoute
    {
        public static List<RouteSpec> AppRoutes = new List<RouteSpec>
        {
            new RouteSpec(
                RouteNames.AboutPage,
                nameof(RouteNames.AboutPage),
                PhysicalPath.AboutAspx
            ),
            new RouteSpec(
                RouteNames.ContactPage,
                nameof(RouteNames.ContactPage),
                PhysicalPath.ContactAspx
            ),
            new RouteSpec(
                RouteNames.ManagementPage,
                nameof(RouteNames.ManagementPage),
                PhysicalPath.ManagementAspx
            ),
            new RouteSpec(
                RouteNames.ErrorPage,
                nameof(RouteNames.ErrorPage),
                PhysicalPath.ErrorAspx
            ),
        };
    }
}
