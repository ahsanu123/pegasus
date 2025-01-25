Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Configuration

Namespace ASPNET4InPractice
	Public Class ErrorModule
		Implements IHttpModule
		Public ReadOnly Property AdministrativeRole() As String
			Get
				' get admnistrative role from web.config
				Return ConfigurationManager.AppSettings("admnistrativeRole")
			End Get
		End Property

		Public Sub Dispose() Implements IHttpModule.Dispose
			' nothing to do
		End Sub

		Public Sub Init(ByVal context As HttpApplication) Implements IHttpModule.Init
			' register for Error event
			AddHandler context.Error, AddressOf OnError
		End Sub

		Private Sub OnError(ByVal sender As Object, ByVal e As EventArgs)
			Dim app As HttpApplication = DirectCast(sender, HttpApplication)
			Dim ex As HttpException = TryCast(app.Server.GetLastError(), HttpException)

			' if user is in AdministrativeRole
			If app.User.IsInRole(AdministrativeRole) Then
				' clear Response stream and output error message
				app.Response.Clear()

				' this flag will prevent IIS 7 from displaying its own custom error pages
				app.Response.TrySkipIisCustomErrors = True

				app.Response.Write(String.Format("<h1>This error is only visible to '{0}' members.</h1>", AdministrativeRole))
				app.Response.Write(ex.GetHtmlErrorMessage())

				' gracefully complete request
				app.Context.ApplicationInstance.CompleteRequest()
			End If
		End Sub
	End Class

End Namespace