Imports System.ComponentModel.DataAnnotations

Public Class EmailAddressAttribute
    Inherits RegularExpressionAttribute

    Friend Const EmailRegex As String =
        "\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}\b"

    Public Sub New()
        MyBase.New(EmailRegex)
    End Sub
End Class