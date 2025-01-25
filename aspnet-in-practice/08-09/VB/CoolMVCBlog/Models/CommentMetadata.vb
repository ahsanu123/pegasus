Imports System.ComponentModel.DataAnnotations

Public Class CommentMetadata

    <Required(ErrorMessage:="Author is mandatory")>
    Public Property Author As String

    <Required(ErrorMessage:="Email is mandatory")>
    <RegularExpression("\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}\b", ErrorMessage:="Please provide a valid Email address")>
    Public Property Email As String

    <Required(ErrorMessage:="You should post some text")>
    <DataType(DataType.MultilineText)>
    Public Property Text As String
End Class

<MetadataType(GetType(CommentMetadata))>
Partial Public Class Comment

End Class
