Imports System.Runtime.CompilerServices

Public Module Extensions

    <Extension()>
    Public Function GetUniqueName(ByVal post As Post) As String
        If (post Is Nothing) Then
            Throw New ArgumentNullException("post")
        End If

        Dim ctx = HttpContext.Current
        Dim cacheKey = "post-staticurl-" + post.Id.ToString()

        Dim res As String = CStr(ctx.Cache(cacheKey))

        If (String.IsNullOrEmpty(res)) Then
            res = Regex.Replace(post.Title, "[^A-Za-z0-9\s]", String.Empty)
            res = Regex.Replace(res, "\s", "-")

            ctx.Cache.Insert(cacheKey, res, Nothing, DateTime.UtcNow.AddMinutes(20), Cache.NoSlidingExpiration)
        End If

        Return res
    End Function
End Module
