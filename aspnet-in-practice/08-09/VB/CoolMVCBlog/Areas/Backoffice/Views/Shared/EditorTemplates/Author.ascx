<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of Nullable(Of Integer))" %>
<%@ Import Namespace="System.Linq" %>
<script runat="server">
    Public Function GetItems() As IEnumerable(Of SelectListItem)
        
        Return New SelectList(TryCast(Me.ViewData("Authors"), IEnumerable),
            "Id", "Name", Me.Model)
    End Function
</script>
<%= Html.DropDownList("", Me.GetItems(), "Please select an author")%>
