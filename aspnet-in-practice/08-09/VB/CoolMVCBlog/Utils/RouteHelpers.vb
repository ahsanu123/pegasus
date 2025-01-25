Imports System.Runtime.CompilerServices

Public Module RouteHelpers
    <Extension()>
    Public Function AppendTrailingSlash(ByVal url As String) As String
        Dim indexOfQueryString As Integer = url.IndexOf("?")

        If indexOfQueryString <> -1 Then
            url = String.Concat(
                VirtualPathUtility.AppendTrailingSlash(url.Substring(0, indexOfQueryString)),
                url.Substring(indexOfQueryString))
        Else
            url = VirtualPathUtility.AppendTrailingSlash(url)
        End If

        Return url
    End Function

    <Extension()>
    Public Function GetExtension(ByVal url As String) As String
        Dim indexOfQueryString As Integer = url.IndexOf("?")
        If indexOfQueryString <> -1 Then
            url = url.Substring(0, indexOfQueryString)
        End If

        ' url is domain name
        If url.ToLower().StartsWith("http://") AndAlso
            url.Substring(7).IndexOf("/") = -1 Then
            Return String.Empty
        End If

        Return VirtualPathUtility.GetExtension(url)
    End Function

    <Extension()>
    Public Function MapSEORoute(ByVal routes As RouteCollection, ByVal name As String, ByVal url As String, ByVal defaults As Object) As Route
        Return MapSEORoute(routes, name, url, defaults, Nothing)
    End Function

    <Extension()>
    Public Function MapSEORoute(ByVal routes As RouteCollection, ByVal name As String, ByVal url As String, ByVal defaults As Object, ByVal constraints As Object) As Route
        Dim route = New SEORoute(
                    url, New RouteValueDictionary(defaults),
                    New RouteValueDictionary(constraints),
                    New MvcRouteHandler())

        routes.Add(name, route)

        Return route
    End Function
End Module