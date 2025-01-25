Namespace CoolMvcBlog.Areas.Backoffice.Controllers
    Public Class PostController
        Inherits Controller

        Public Function Index() As ActionResult
            Return Me.View(ObjectContextModule.CurrentContext.
                           PostSet.
                           Include("Author").
                           OrderByDescending(Function(p) p.DatePublished).
                           ToList)
        End Function

        <HttpGet()>
        Public Function Edit(ByVal id As Integer) As ActionResult
            Me.ViewData("Authors") = AuthorsService.GetAuthors()
            Me.ViewData("Categories") = CategoriesService.GetCategories()

            Return View(ObjectContextModule.CurrentContext.
                        PostSet.
                        Include("Author").
                        Include("Categories").
                        Where(Function(p) p.Id = id).
                        Single())
        End Function

        <HttpPost()>
        Public Function Edit(ByVal post As Post) As ActionResult
            If Me.ModelState.IsValid Then
                ObjectContextModule.CurrentContext.SaveChanges()
                Return Me.RedirectToAction("Index")
            End If

            Me.ViewData("Authors") = AuthorsService.GetAuthors()
            Me.ViewData("Categories") = CategoriesService.GetCategories()

            Return Me.View(post)
        End Function

        '<HttpPost()>
        'Public Function Edit(ByVal post As Post) As ActionResult
        '    If Me.ModelState.IsValid Then
        '        Using ctx As New BlogModelContainer
        '            Dim original = ctx.PostSet.
        '                Where(Function(p) p.Id = post.Id).
        '                Single

        '            If Me.TryUpdateModel(original) Then
        '                ctx.SaveChanges()
        '                Return Me.RedirectToAction("Index")
        '            End If
        '        End Using
        '    End If

        '    Me.ViewData("Authors") = AuthorsService.GetAuthors()
        '    Me.ViewData("Categories") = CategoriesService.GetCategories()

        '    Return Me.View(post)
        'End Function

    End Class
End Namespace