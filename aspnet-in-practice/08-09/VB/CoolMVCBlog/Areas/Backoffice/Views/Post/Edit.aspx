<%@ Page Title="" Language="VB" MasterPageFile="~/Areas/Backoffice/Views/Shared/Backoffice.Master" Inherits="System.Web.Mvc.ViewPage(Of CoolMvcBlog.Post)" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainBOContent" runat="server">
    <h2>
        Edit</h2>
    <% Using Html.BeginForm()%>
    <%: Html.ValidationSummary(True) %>
    <fieldset>
        <legend>Fields</legend>
        <div class="editor-label">
            <%: Html.LabelFor(Function(model) model.Author)%>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(Function(model) model.AuthorId)%>
            <%: Html.ValidationMessageFor(Function(model) model.AuthorId, "*")%>
        </div>
        <div class="clear">
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(Function(model) model.Title) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(Function(model) model.Title)%>
            <%: Html.ValidationMessageFor(Function(model) model.Title, "*")%>
        </div>
        <div class="clear">
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(Function(model) model.Text) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(Function(model) model.Text)%>
            <%: Html.ValidationMessageFor(Function(model) model.Text, "*")%>
        </div>
        <div class="clear">
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(Function(model) model.DatePublished) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(Function(model) model.DatePublished)%>
            <%: Html.ValidationMessageFor(Function(model) model.DatePublished) %>
        </div>
        <div class="clear">
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(Function(model) model.Categories)%>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(Function(model) model.Categories)%>
            <%: Html.ValidationMessageFor(Function(model) model.Categories, "*")%>
        </div>
        <div class="clear">
        </div>
        <div class="editor-label">
            &nbsp;</div>
        <div class="editor-field">
            <input type="submit" value="Save post" />
        </div>
        <div class="clear">
        </div>
    </fieldset>
    <% End Using%>
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
