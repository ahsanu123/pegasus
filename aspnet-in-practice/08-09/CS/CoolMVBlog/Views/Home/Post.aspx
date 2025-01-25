<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CoolMvcBlog.Models.Post>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    CoolMvcBlog -
    <%: this.Model.Title %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <h2>
            <%: this.Model.Title%></h2>
        <div>
            <%: this.Model.Text%>
        </div>
        <div class="comments">
            <% if (this.Model.Comments.Count == 0)
               { %>
            <div class="comment"><i>No comments posted yet...</i></div>
            <% } %>
            <% foreach (var comment in this.Model.Comments)
               {
                   Html.RenderPartial("Comment", comment);
               }

               Html.RenderPartial("NewComment", new CoolMvcBlog.Models.Comment()); %>
        </div>
    </div>
</asp:Content>
