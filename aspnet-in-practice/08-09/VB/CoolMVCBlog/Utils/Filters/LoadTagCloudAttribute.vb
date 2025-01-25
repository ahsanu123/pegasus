Public Class LoadTagCloudAttribute
    Inherits ActionFilterAttribute

    Public Overrides Sub OnResultExecuting(ByVal filterContext As ResultExecutingContext)
        MyBase.OnResultExecuting(filterContext)

        Dim view = TryCast(filterContext.Result, ViewResult)
        If view Is Nothing Then
            Return
        End If

        Dim model = TryCast(view.ViewData.Model, IHasTagCloud)
        If model Is Nothing Then
            Return
        End If

        Using ctx As New BlogModelContainer
            Dim service = New TagCloudService(ctx)
            model.TagCloudItems = service.GetTagCloudItems
        End Using

    End Sub

End Class