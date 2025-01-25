Imports System.Data.Objects.DataClasses

' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapSEORoute(
                "Post",
                "Post/{id}/{uniqueName}",
                New With {.controller = "Home", .action = "Post"}
            )

        routes.MapSEORoute( _
            "Default", _
            "{controller}/{action}/{id}", _
            New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional} _
        )

    End Sub

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()

        RegisterRoutes(RouteTable.Routes)

        ModelBinders.Binders(GetType(Post)) =
            New PostModelBinder
        ModelBinders.Binders(GetType(EntityCollection(Of Category))) =
            New CategoriesModelBinder

        DataAnnotationsModelValidatorProvider.
                RegisterAdapter(GetType(EmailAddressAttribute), GetType(EmailAddressValidator))
    End Sub
End Class
