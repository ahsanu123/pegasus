Imports System
Imports System.Web
Imports System.IO

Public Class DirectoryListingModuleManaged
    Implements IHttpModule
    Public Sub Init(ByVal application As HttpApplication) Implements IHttpModule.Init
        ' register for EndRequest event
        AddHandler application.EndRequest, AddressOf application_EndRequest
    End Sub

    Private Sub application_EndRequest(ByVal sender As Object, ByVal e As EventArgs)
        Dim context As HttpContext = DirectCast(sender, HttpApplication).Context
        If True Then
            ' this is true only when no specific page is requested
            If Path.GetFileName(context.Request.Url.AbsolutePath).Length = 0 OrElse Path.GetFileName(context.Request.Url.AbsolutePath).Equals(Path.GetFileNameWithoutExtension(context.Request.Url.AbsolutePath), StringComparison.InvariantCultureIgnoreCase) Then
                context.Response.Clear()
                context.Response.Write("<p>This is a custom default page. Add your custom login here.</p>")
                context.Response.End()
            End If
        End If
    End Sub

    Public Sub Dispose() Implements IHttpModule.Dispose
        'nothing 
    End Sub
End Class