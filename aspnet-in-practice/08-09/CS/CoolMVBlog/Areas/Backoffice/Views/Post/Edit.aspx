<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Backoffice/Views/Shared/Backoffice.Master"
    Inherits="System.Web.Mvc.ViewPage<CoolMvcBlog.Models.Post>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainBOContent" runat="server">
        <h2>
            Edit</h2>
        <% using (Html.BeginForm())
           {%>
        <%: Html.ValidationSummary(true) %>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Author) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.AuthorId)%>
            <%: Html.ValidationMessageFor(model => model.AuthorId, "*") %>
        </div>
        <div class="clear">
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Title) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Title)%>
            <%: Html.ValidationMessageFor(model => model.Title, "*")%>
        </div>
        <div class="clear">
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Text)%>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Text)%>
            <%: Html.ValidationMessageFor(model => model.Text, "*") %>
        </div>
        <div class="clear">
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.DatePublished) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.DatePublished)%>
            <%: Html.ValidationMessageFor(model => model.DatePublished, "*")%>
        </div>
        <div class="clear">
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Categories) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Categories)%>
            <%: Html.ValidationMessageFor(model => model.Categories)%>
        </div>
        <div class="clear"></div>
        <div class="editor-label">
            &nbsp;</div>
        <div class="editor-field">
            <input type="submit" value="Save post" />
        </div>
        <div class="clear">
        </div>
        <% } %>
        <div>
            <%: Html.ActionLink("Back to List", "Index") %>
        </div>
</asp:Content>
