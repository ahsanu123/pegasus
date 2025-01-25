Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Configuration
Imports System.IO
Imports System.Web.UI
Imports System.Text.RegularExpressions
Imports System.Web.Caching

Namespace ASPNET4InPractice.Chapter14
    Public Class CssHandler
        Implements IHttpHandler
        Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
            ' true if you have no instance specific information
            Get
                Return True
            End Get
        End Property

        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
            Dim fileContent As String = String.Empty
            Dim filePath As String = context.Request.PhysicalPath
            Dim cacheKey As String = String.Concat("css-", filePath)
            Dim cacheValue As Object = context.Cache(cacheKey)

            If cacheValue Is Nothing Then
                fileContent = AddInCache(filePath, cacheKey)
            Else
                fileContent = TryCast(cacheValue, String)
            End If

            ' set the appropriate content type
            context.Response.ContentType = "text/css"
            context.Response.Write(fileContent)
        End Sub

        Private Shared Function AddInCache(ByVal filePath As String, ByVal cacheKey As String) As String
            ' then write out the file
            Dim fileContent As String = File.ReadAllText(filePath)
            fileContent = String.Concat("/* minifyed at ", DateTime.Now, "*/ ", fileContent)

            fileContent = Regex.Replace(fileContent, vbTab, String.Empty)
            fileContent = Regex.Replace(fileContent, vbCr & vbLf, String.Empty)
            fileContent = Regex.Replace(fileContent, vbCr, String.Empty)
            fileContent = Regex.Replace(fileContent, vbLf, String.Empty)

            ' this will remove more than 2 spaces sequences
            fileContent = Regex.Replace(fileContent, "[ ]{2,}", String.Empty)

            ' add to cache for 2 hours
            HttpContext.Current.Cache.Insert(cacheKey, fileContent, New CacheDependency(filePath), DateTime.Now.AddHours(2), TimeSpan.Zero)

            Return fileContent
        End Function

    End Class

End Namespace