Imports System.Runtime.CompilerServices

Public Module Helpers

    <Extension()>
    Public Function Login(ByVal html As HtmlHelper, ByVal controller As String, ByVal loginAction As String, ByVal logoutAction As String) As HtmlString
        If HttpContext.Current.User.Identity.IsAuthenticated Then
            Return WelcomeMessage(html, logoutAction, controller)
        Else
            Return LoginInput(html, loginAction, controller)
        End If
    End Function

    Private Function WelcomeMessage(ByVal html As HtmlHelper, ByVal logoutAction As String, ByVal controller As String) As HtmlString
        Return New HtmlString(String.Format("Welcome {0} :: {1}",
                            HttpContext.Current.User.Identity.Name,
                            html.ActionLink("Logout", logoutAction, controller)))
    End Function

    Private Function LoginInput(ByVal html As HtmlHelper, ByVal loginAction As String, ByVal controller As String) As HtmlString
        Dim form As New TagBuilder("form")

        form.MergeAttribute("action", UrlHelper.GenerateUrl(Nothing, loginAction, controller, New RouteValueDictionary, html.RouteCollection, html.ViewContext.RequestContext, True))
        form.MergeAttribute("method", "post")
        form.InnerHtml = String.Format("User: {0} Pass: {1} {2}",
                                       html.TextBox("username"),
                                       html.TextBox("password"),
                                       "<input type=""submit"" value=""Login"" />")

        Return New HtmlString(form.ToString())
    End Function

End Module