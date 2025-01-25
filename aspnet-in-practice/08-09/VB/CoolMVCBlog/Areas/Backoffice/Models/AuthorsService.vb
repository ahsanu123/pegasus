Public Class AuthorsService
    Public Shared Function GetAuthors() As List(Of Author)
        Dim context = HttpContext.Current
        If context Is Nothing Then
            Throw New InvalidOperationException("A valid HttpContext is needed")
        End If

        Dim res = TryCast(context.Cache("authors.all"), List(Of Author))
        If res Is Nothing Then
            res = ObjectContextModule.CurrentContext.AuthorSet.ToList()
            context.Cache.Insert("authors.all", res, Nothing,
                                 DateTime.Now.AddHours(1), Cache.NoSlidingExpiration)
        End If

        Return res
    End Function
End Class
