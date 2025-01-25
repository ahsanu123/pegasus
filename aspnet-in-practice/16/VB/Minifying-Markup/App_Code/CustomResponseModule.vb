Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Configuration
Imports System.IO
Imports System.Web.UI

Namespace ASPNET4InPractice.Chapter14
    Public Class CustomResponseModule
        Implements IHttpModule
        Public Sub Dispose() Implements IHttpModule.Dispose
            ' nothing to do
        End Sub

        Public Sub Init(ByVal context As HttpApplication) Implements IHttpModule.Init
            AddHandler context.PreRequestHandlerExecute, AddressOf AddFilter
        End Sub

        Private Sub AddFilter(ByVal sender As Object, ByVal e As EventArgs)
            Dim app As HttpApplication = DirectCast(sender, HttpApplication)

            ' ignore non page and AJAX requests
            If Not (TypeOf app.Context.CurrentHandler Is Page) OrElse Not String.IsNullOrEmpty(app.Request("HTTP_X_MICROSOFTAJAX")) Then
                Exit Sub
            End If

            ' this is a bug in ASP.NET>3.5, you just need to first access Request.Filter
            Dim filter As Stream = app.Response.Filter

            ' and then add our custom Filter
            app.Response.Filter = New ResponseFilter(app.Response.OutputStream)
        End Sub

    End Class

End Namespace