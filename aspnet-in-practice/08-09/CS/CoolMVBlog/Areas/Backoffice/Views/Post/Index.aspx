<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Backoffice/Views/Shared/Backoffice.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CoolMvcBlog.Models.Post>>" %>

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

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.Id })%>
            </td>
            <td>
                <%: item.Title %>
            </td>
            <td>
                <%: item.Author.Name %>
            </td>
            <td>
                <%: Html.DisplayFor(m => item.DatePublished) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
</asp:Content>

