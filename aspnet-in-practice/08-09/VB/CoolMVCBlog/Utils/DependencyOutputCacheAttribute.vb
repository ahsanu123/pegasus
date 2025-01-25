Public Class DependencyOutputCacheAttribute
    Inherits OutputCacheAttribute

    Public Property ParameterName As String
    Public Property BasePrefix As String

    Public Overrides Sub OnResultExecuting(ByVal filterContext As ResultExecutingContext)
        MyBase.OnResultExecuting(filterContext)

        Dim key As String
        If String.IsNullOrEmpty(BasePrefix) Then
            key = filterContext.RouteData.Values("action").ToString + "_" +
                                filterContext.RouteData.Values("controller").ToString
        Else
            key = BasePrefix
        End If

        If Not String.IsNullOrEmpty(ParameterName) Then
            key += "_" + filterContext.RouteData.Values(ParameterName).ToString
        End If

        filterContext.HttpContext.Cache.Insert(
            key, key, Nothing, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration)
        filterContext.HttpContext.Response.AddCacheItemDependency(key)
    End Sub

End Class

Public Class RemoveCachedAttribute
    Inherits ActionFilterAttribute

    Public Property ParameterName As String
    Public Property BasePrefix As String

    Public Overrides Sub OnResultExecuting(ByVal filterContext As ResultExecutingContext)
        MyBase.OnResultExecuting(filterContext)

        Dim key As String
        If String.IsNullOrEmpty(BasePrefix) Then
            key = filterContext.RouteData.Values("action").ToString + "_" +
                                filterContext.RouteData.Values("controller").ToString
        Else
            key = BasePrefix
        End If

        If Not String.IsNullOrEmpty(ParameterName) Then
            key += "_" + filterContext.RouteData.Values(ParameterName).ToString
        End If

        filterContext.HttpContext.Cache.Remove(key)
    End Sub
End Class