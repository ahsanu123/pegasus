Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.IO

Public Module PathExtensions
    Public Function CanonicalCombine(ByVal basePath As String, ByVal myPath As String) As String
        If String.IsNullOrEmpty(basePath) OrElse String.IsNullOrEmpty(myPath) Then
            Throw New ArgumentNullException()
        End If

        ' let's decode paramters
        basePath = HttpUtility.UrlDecode(basePath)
        myPath = HttpUtility.UrlDecode(myPath)

        If myPath.IndexOfAny(Path.GetInvalidFileNameChars()) > -1 Then
            Throw New FileNotFoundException("FileName not valid")
        End If

        Dim filePath As String = Path.Combine(basePath, myPath)
        If Not filePath.StartsWith(basePath) Then
            Throw New FileNotFoundException("Path not valid")
        End If

        Return filePath
    End Function
End Module