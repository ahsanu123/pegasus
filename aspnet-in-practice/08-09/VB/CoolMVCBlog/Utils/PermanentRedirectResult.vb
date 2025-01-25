Public Class PermanentRedirectResult
    Inherits ActionResult

    Private innerResult As ActionResult

    Public Sub New(ByVal result As RedirectToRouteResult)
        If result Is Nothing Then
            Throw New ArgumentNullException("result")
        End If

        Me.innerResult = result
    End Sub

    Public Overrides Sub ExecuteResult(ByVal context As ControllerContext)
        Me.innerResult.ExecuteResult(context)

        Dim response = context.HttpContext.Response
        Dim url = response.RedirectLocation

        response.RedirectPermanent(url, False)
    End Sub
End Class