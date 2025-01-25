Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Text.RegularExpressions

Public Module SecurityUtility

    Public Function RemoveHtml(ByVal text As String) As String
        Return Regex.Replace(text, "<[^>]*>", [String].Empty)
    End Function

    Public Function BBCode(ByVal text As String) As String
        text = text.Replace("[b]", "<b>").Replace("[/b]", "</b>")
        text = text.Replace("[i]", "<i>").Replace("[/i]", "</i>")
        text = text.Replace("[u]", "<u>").Replace("[/u]", "</u>")
        Return text
    End Function
End Module