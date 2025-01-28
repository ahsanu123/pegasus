using System.Collections.Generic;

namespace WingtipToys.Routes
{
    public static class RouteNames
    {
        public const string AboutPage = "about-page";
        public const string CustomEventPage = "custom-event-page";
        public const string ContactPage = "contact-page";
        public const string ManagementPage = "management-page";
        public const string ErrorPage = "error-page";
        public const string DataSelectPage = "data-select-page";
    }

    public static class PhysicalPath
    {
        public const string AboutAspx = "~/Pages/About.aspx";
        public const string CustomEventPageAspx = "~/Pages/CustomEventPage.aspx";
        public const string ContactAspx = "~/Pages/Contact.aspx";
        public const string ManagementAspx = "~/Pages/Management.aspx";
        public const string ErrorAspx = "~/Pages/ErrorPage.aspx";
        public const string DataSelectPage = "~/Pages/DataSelectPage.aspx";
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
                RouteNames.CustomEventPage,
                nameof(RouteNames.CustomEventPage),
                PhysicalPath.CustomEventPageAspx
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
            new RouteSpec(
                RouteNames.DataSelectPage,
                nameof(RouteNames.DataSelectPage),
                PhysicalPath.DataSelectPage
            ),
        };
    }
}
