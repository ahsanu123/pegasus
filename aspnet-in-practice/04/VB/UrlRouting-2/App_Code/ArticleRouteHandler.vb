Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Compilation
Imports System.Web.Routing
Imports System.Web.UI

Public Class ArticleRouteHandler
	Implements IRouteHandler
	Private Function GetHttpHandler(ByVal requestContext As RequestContext) As IHttpHandler Implements IRouteHandler.GetHttpHandler
		Dim realUrl As String = requestContext.RouteData.DataTokens("finalUrl").ToString()
		Dim virtualPath As String = VirtualPathUtility.ToAbsolute(realUrl)

		Dim pp As IArticlePage = TryCast(BuildManager.CreateInstanceFromVirtualPath(virtualPath, GetType(Page)), IArticlePage)

		pp.Id = Convert.ToInt32(requestContext.RouteData.Values("id"))
		pp.Description = TryCast(requestContext.RouteData.Values("Description"), [String])
		Return pp
	End Function
End Class