Public Class ObjectContextModule
    Implements IHttpModule

    Private Const sessionKey As String = "objectcontext.current"

    Public Sub Dispose() Implements IHttpModule.Dispose

    End Sub

    Public Sub Init(ByVal context As HttpApplication) Implements IHttpModule.Init
        AddHandler context.PostAcquireRequestState,
            Sub(s, e)
                If Not HttpContext.Current Is Nothing AndAlso
                   Not HttpContext.Current.Session Is Nothing Then
                    CurrentContext = New BlogModelContainer()
                End If
            End Sub

        AddHandler context.ReleaseRequestState,
            Sub(s, e)
                If Not HttpContext.Current Is Nothing AndAlso
                   Not HttpContext.Current.Session Is Nothing Then
                    CurrentContext.Dispose()
                    CurrentContext = Nothing
                End If

            End Sub
    End Sub

    Public Shared Property CurrentContext As BlogModelContainer
        Get
            Return TryCast(HttpContext.Current.Session(sessionKey), BlogModelContainer)
        End Get
        Set(ByVal value As BlogModelContainer)
            HttpContext.Current.Session(sessionKey) = value
        End Set
    End Property
End Class