<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CoolMvcBlog.Models.HomepageModel>" %>
<%@ Import Namespace="CoolMvcBlog.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <% foreach (var i in this.Model.Posts)
           { %>
        <h2><%: this.Html.RouteLink(i.Title, "Post", new { id = i.Id, uniqueName = i.GetUniqueName() })%></h2>
        <div>
            <%: i.Text %>
        </div>
        <% } %>
    </div>
    <div class="menu">
        <div class="menu_title">
            Tag cloud</div>
        <% foreach (var i in this.Model.TagCloudItems)
           { %>
                <%= Html.ActionLink(i.Description, "Tag", 
                    new { Id = i.CategoryId }, 
                    new { style = "font-size: " + i.Size, @class = "menu_link" }) %>
        <% } %>
    </div>
</asp:Content>
