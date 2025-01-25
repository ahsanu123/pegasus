Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text
Imports System.Data.SqlClient

Partial Public Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Protected Sub SubmitButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim sql As New StringBuilder("SELECT * FROM Products WHERE Category IN (")
        Dim categories As String() = Request("Categories").Split(","c)

        Dim paramters As SqlParameter() = New SqlParameter(categories.Length - 1) {}

        For i As Integer = 0 To categories.Length - 1
            sql.AppendFormat("@p{0}, ", i)
            paramters(i) = New SqlParameter(String.Format("@p{0}", i), categories(i))
        Next
        sql.Append("0)")

        Response.Write(sql.ToString())
    End Sub
End Class