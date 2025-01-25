Public Class SEORedirectModule
    Implements IHttpModule

    Public Sub Dispose() Implements IHttpModule.Dispose

    End Sub

    Public Sub Init(ByVal context As HttpApplication) Implements IHttpModule.Init
        AddHandler context.BeginRequest, AddressOf context_BeginRequest
    End Sub

    Private Sub context_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        Dim context = HttpContext.Current
        Dim url = context.Request.Url.AbsoluteUri

        If Not String.IsNullOrEmpty(url.GetExtension()) Then
            Return
        End If

        Dim newUrl As String = url.AppendTrailingSlash()

        If newUrl <> context.Request.Url.AbsoluteUri Then
            context.Response.RedirectPermanent(newUrl)
        End If
    End Sub
End Class