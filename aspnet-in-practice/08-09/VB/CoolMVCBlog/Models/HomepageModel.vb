Public Class HomepageModel
    Implements IHasTagCloud

    Public Property Posts As List(Of Post)
    Public Property TagCloudItems As List(Of TagCloudItem) _
        Implements IHasTagCloud.TagCloudItems

End Class