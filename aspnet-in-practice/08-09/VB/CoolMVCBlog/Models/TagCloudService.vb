Public Class TagCloudService
    Private context As BlogModelContainer

    Public Sub New(ByVal context As BlogModelContainer)
        Me.context = context
    End Sub

    Public Function GetTagCloudItems() As List(Of TagCloudItem)
        Dim q = (From p In context.PostSet
                 From c In p.Categories
                 Group p By IdKey = c.Id, DescriptionKey = c.Description Into Group
                 Select New With
                        {
                            .CategoryId = IdKey,
                            .Description = DescriptionKey,
                            .Size = Group.Count()
                            }).ToList()

        Dim max = q.Max(Function(i) i.Size)

        Dim res = q.Select(Function(i) New TagCloudItem() With
                                       {
                                           .CategoryId = i.CategoryId,
                                           .Description = i.Description,
                                           .Size = Me.GetSize(i.Size, max)
                                       })

        Return res.ToList()
    End Function

    Private Function GetSize(ByVal size As Integer, ByVal max As Integer) As String
        Dim threshold1 = max * 0.4
        Dim threshold2 = max * 0.8

        If size >= threshold2 Then
            Return "100%"
        End If

        If size >= threshold1 Then
            Return "80%"
        End If

        Return "60%"
    End Function
End Class