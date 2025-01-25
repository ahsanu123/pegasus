Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Routing

Partial Public Class Redirect
	Inherits System.Web.UI.Page
	Protected Sub TestRedirect(ByVal sender As Object, ByVal e As EventArgs)
		Response.RedirectToRoute("ArticleRoute", New RouteValueDictionary From {{"Id", 5}, {"Description", "Test-URL"}})
	End Sub
End Class