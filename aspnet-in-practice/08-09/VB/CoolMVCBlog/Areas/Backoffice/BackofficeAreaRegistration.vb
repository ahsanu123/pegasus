Namespace CoolMvcBlog.Areas.Backoffice
    Public Class BackofficeAreaRegistration
        Inherits AreaRegistration

        Public Overrides ReadOnly Property AreaName() As String
            Get
                Return "Backoffice"
            End Get
        End Property

        Public Overrides Sub RegisterArea(ByVal context As System.Web.Mvc.AreaRegistrationContext)
            context.MapRoute( _
                "Backoffice_default", _
               "Backoffice/{controller}/{action}/{id}", _
                New With {.action = "Index", .id = UrlParameter.Optional} _
            )
        End Sub
    End Class
End Namespace

