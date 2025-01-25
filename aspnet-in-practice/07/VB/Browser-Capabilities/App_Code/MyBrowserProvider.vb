Imports System.Web.Configuration
Imports System.Web
Imports System
Imports System.Collections
Imports System.Web.Caching

Namespace ASPNET4InPractice
    Public Class MyBrowserProvider
        Inherits HttpCapabilitiesProvider
        Public Overloads Overrides Function GetBrowserCapabilities(ByVal request As HttpRequest) As HttpBrowserCapabilities
            Dim cacheKey As String = If("MyBrowserProvider_" & request.UserAgent, "empty")
            Dim cacheTimeout As Integer = 360
            
            Dim browserCaps As HttpBrowserCapabilities = TryCast(HttpContext.Current.Cache(cacheKey), HttpBrowserCapabilities)
            If browserCaps Is Nothing Then
                browserCaps = New HttpBrowserCapabilities()
                Dim values As New Hashtable(20, StringComparer.OrdinalIgnoreCase)
                values("browser") = request.UserAgent
                values("tables") = "true"
                values("supportsRedirectWithCookie") = "true"
                values("cookies") = "true"
                values("ecmascriptversion") = "3.0"
                values("w3cdomversion") = "1.0"
                values("jscriptversion") = "6.0"
                values("tagwriter") = "System.Web.UI.HtmlTextWriter"
                
                values("IsIPhone") = ((If(request.UserAgent, String.Empty)).IndexOf("iphone") > -1).ToString()
                
                browserCaps.Capabilities = values
                HttpRuntime.Cache.Add(cacheKey, browserCaps, Nothing, DateTime.Now.AddSeconds(cacheTimeout), TimeSpan.Zero, CacheItemPriority.Low, _ 
                Nothing)
            End If
            
            Return browserCaps
        End Function
    End Class
End Namespace