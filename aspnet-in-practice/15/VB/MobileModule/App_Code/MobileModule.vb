Imports System
Imports System.Web
Imports System.Web.UI

Namespace ASPNET4InPractice.Chapter13
    Public Class MobileModule
        Implements IHttpModule
        Public Sub Dispose() Implements IHttpModule.Dispose
            ' nothing
        End Sub

        Public Sub Init(ByVal context As HttpApplication) Implements IHttpModule.Init
            AddHandler context.PreRequestHandlerExecute, AddressOf CheckMobileRequest
        End Sub

        Private Sub CheckMobileRequest(ByVal sender As Object, ByVal e As EventArgs)
            Dim app As HttpApplication = TryCast(sender, HttpApplication)

            ' if the request is coming from a mobile device, mark it
            If app.Request.Browser.IsMobileDevice Then
                app.Context.Items("isMobile") = True
                ModifyMasterPage(app)
            End If
        End Sub

        Private Sub ModifyMasterPage(ByVal app As HttpApplication)
            If TypeOf app.Context.Handler Is Page Then
                AddHandler DirectCast(app.Context.Handler, Page).PreInit, AddressOf ApplyMasterPage
            End If
        End Sub

        Private Sub ApplyMasterPage(ByVal sender As Object, ByVal e As EventArgs)
            DirectCast(sender, Page).MasterPageFile = "~/Masters/Mobile.master"
        End Sub


    End Class
End Namespace