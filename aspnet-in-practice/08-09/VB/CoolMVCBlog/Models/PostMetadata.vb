Imports System.ComponentModel.DataAnnotations
Imports System.Data.Objects.DataClasses

Public Class PostMetadata
    <UIHint("Author")>
    Public Property AuthorId As Integer

    <UIHint("Categories")>
    Public Property Categories As EntityCollection(Of Category)

    <DataType(DataType.MultilineText)>
    Public Property Text As String
End Class

<MetadataType(GetType(PostMetadata))>
Partial Public Class Post

End Class