<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl" %>
<script runat="server">
    Private ReadOnly Property DateString As String
        Get
            If Me.Model Is Nothing Then
                Return Nothing
            End If
            
            Return DirectCast(Me.Model, DateTime).ToShortDateString
        End Get
    End Property
</script>
<%= Html.TextBox("", DateString, New With {.Class = "dateInput"})%>
