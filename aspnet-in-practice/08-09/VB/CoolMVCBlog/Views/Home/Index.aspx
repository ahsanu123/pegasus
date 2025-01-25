<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of CoolMvcBlog.HomepageModel)" %>
<%@ Import Namespace="CoolMvcBlog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <% For Each i in me.Model.Posts %>
        <h2><%: Me.Html.RouteLink(i.Title, "Post", New With {.id = i.Id, .uniqueName = i.GetUniqueName()})%></h2>
        <div>
            <%: i.Text %>
        </div>
        <% Next%>
    </div>
    <div class="menu">
        <div class="menu_title">
            Tag cloud</div>
        <% For Each i In Me.Model.TagCloudItems%>
                <%= Html.ActionLink(i.Description, "Tag",
                                        New With {.Id = i.CategoryId},
                                        New With {.style = "font-size: " + i.Size, .class = "menu_link"})%>
        <% Next%>
    </div>
</asp:Content>
