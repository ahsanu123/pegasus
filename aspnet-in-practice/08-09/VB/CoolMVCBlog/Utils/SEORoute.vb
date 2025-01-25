Public Class SEORoute
    Inherits Route

    Public Sub New(ByVal url As String, ByVal routeHandler As IRouteHandler)
        MyBase.New(url, routeHandler)
    End Sub

    Public Sub New(ByVal url As String, ByVal defaults As RouteValueDictionary, ByVal routeHandler As IRouteHandler)
        MyBase.New(url, defaults, routeHandler)
    End Sub

    Public Sub New(ByVal url As String, ByVal defaults As RouteValueDictionary, ByVal constraints As RouteValueDictionary, ByVal routeHandler As IRouteHandler)
        MyBase.New(url, defaults, constraints, routeHandler)
    End Sub

    Public Sub New(ByVal url As String, ByVal defaults As RouteValueDictionary, ByVal constraints As RouteValueDictionary, ByVal dataTokens As RouteValueDictionary, ByVal routeHandler As IRouteHandler)
        MyBase.New(url, defaults, constraints, dataTokens, routeHandler)
    End Sub

    Public Overrides Function GetVirtualPath(ByVal requestContext As System.Web.Routing.RequestContext, ByVal values As System.Web.Routing.RouteValueDictionary) As System.Web.Routing.VirtualPathData
        Dim path As VirtualPathData = MyBase.GetVirtualPath(requestContext, values)

        If Not path Is Nothing Then
            path.VirtualPath = path.VirtualPath.AppendTrailingSlash()
        End If

        Return path
    End Function
End Class