Public Class HomeController
    Inherits Controller

    <LoadTagCloud()>
    Public Function Index() As ActionResult
        Using ctx As New BlogModelContainer
            Dim lastPosts = ctx.PostSet.
                OrderBy(Function(p) p.DatePublished).
                Take(3).
                ToList()

            Return View(
                New HomepageModel With {.Posts = lastPosts})
        End Using
    End Function

    <HttpGet()>
    <DependencyOutputCache(Duration:=30,
            Location:=OutputCacheLocation.Server, VaryByParam:="None", ParameterName:="id")>
    Public Function Post(ByVal id As Integer, ByVal uniqueName As String) As ActionResult
        Using ctx = New BlogModelContainer
            Dim thePost = ctx.PostSet.
                Include("Comments").
                Where(Function(p) p.Id = id).
                Single()

            If thePost.GetUniqueName() <> uniqueName Then
                Return New PermanentRedirectResult(Me.RedirectToAction(
                    "Post", New With {.id = id, .uniqueName = thePost.GetUniqueName()}))
            End If

            Return View(thePost)
        End Using
    End Function

    <HttpPost()>
    <RemoveCached(ParameterName:="id")>
    Public Function Post(ByVal id As Integer, ByVal newComment As Comment) As ActionResult
        Using ctx = New BlogModelContainer()
            Dim thePost = ctx.PostSet.
                Include("Comments").
                Where(Function(p) p.Id = id).
                Single()

            If Not Me.ModelState.IsValid Then
                Return Me.View(thePost)
            End If

            newComment.Date = DateTime.Now
            thePost.Comments.Add(newComment)
            ctx.SaveChanges()

            Return Me.RedirectToAction(
                "Post", New With {.id = id, .uniqueName = thePost.GetUniqueName()})
        End Using
    End Function

End Class