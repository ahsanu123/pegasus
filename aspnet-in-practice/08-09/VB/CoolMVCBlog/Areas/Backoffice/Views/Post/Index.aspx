<%@ Page Language="VB" MasterPageFile="~/Areas/Backoffice/Views/Shared/Backoffice.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable(Of CoolMvcBlog.Post))" %>

<%@ Import Namespace="CoolMvcBlog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainBOContent" runat="server">
    <h3>Index</h3>

    <table>
        <tr>
            <th></th>
            <th>
                Title
            </th>
            <th>
                Author
            </th>
            <th>
                Date Published
            </th>
        </tr>

    <% For Each item As Post In Model%>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", New With {.id = item.Id})%> |
                <%: Html.ActionLink("Delete", "Delete", New With {.id = item.Id})%>
            </td>
            <td>
                <%: item.Title %>
            </td>
            <td>
                <%: item.Author.Name %>
            </td>
            <td>
                <%: Html.DisplayFor(Function(m) item.DatePublished)%>
            </td>
        </tr>
    
    <% Next%>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
</asp:Content>

