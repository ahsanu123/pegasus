Public Class CategoriesService
    Public Shared Function GetCategories() As List(Of Category)
        Dim context = HttpContext.Current

        If context Is Nothing Then
            Throw New InvalidOperationException("A valid HttpContext is required")
        End If

        Dim res = TryCast(context.Cache("categories.all"), List(Of Category))
        If res Is Nothing Then
            res = ObjectContextModule.CurrentContext.CategorySet.ToList
            context.Cache.Insert("categories.all", res, Nothing,
                                 DateTime.Now.AddHours(1), Cache.NoSlidingExpiration)
        End If

        Return res
    End Function
End Class