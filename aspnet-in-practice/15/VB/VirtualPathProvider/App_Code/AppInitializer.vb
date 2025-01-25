Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Hosting
Imports ASPNET4InPractice

Public Class AppInitializer
    Public Shared Sub AppInitialize()
        HostingEnvironment.RegisterVirtualPathProvider(New DatabasePathProvider())
    End Sub
End Class