Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Configuration
Imports System.IO
Imports System.Web.UI

Namespace ASPNET4InPractice
	Public Class AuthorizationModule
		Implements IHttpModule
		Public Sub Dispose() Implements IHttpModule.Dispose
			' nothing to do
		End Sub

		Public Sub Init(ByVal context As HttpApplication) Implements IHttpModule.Init
			AddHandler context.AuthorizeRequest, AddressOf OnAuthorizeRequest
		End Sub

		Private Sub OnAuthorizeRequest(ByVal sender As Object, ByVal e As EventArgs)
			Dim app As HttpApplication = DirectCast(sender, HttpApplication)

			' probably you'll implement something more useful than this :)
			If DateTime.Now.Hour >= 17 Then
				app.Context.Response.StatusCode = 401
			End If
		End Sub

	End Class
End Namespace