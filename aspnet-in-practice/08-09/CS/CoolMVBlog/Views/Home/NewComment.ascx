<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CoolMvcBlog.Models.Comment>" %>
<%@ Import Namespace="CoolMvcBlog.Utils.ReCaptcha" %>
    <%--<% Html.EnableClientValidation(); %>--%>
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary("There's something wrong with your comment:") %>
                        
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Author) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Author)%>
                <%: Html.ValidationMessageFor(model => model.Author, "*") %>
            </div>
            <div class="clear"></div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Email) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Email)%>
                <%: Html.ValidationMessageFor(model => model.Email, "*")%>
            </div>
            <div class="clear"></div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.WebSite) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.WebSite) %>
                <%: Html.ValidationMessageFor(model => model.WebSite, "*") %>
            </div>
            <div class="clear"></div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Text) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Text) %>
                <%: Html.ValidationMessageFor(model => model.Text, "*")%>
            </div>
            <div class="clear"></div>

            <div class="editor-label">&nbsp;</div>
            <div class="editor-field">
<%--                <%= Html.ReCaptcha("6Ld69LoSAAAAAAMvgZxhdXum08aLebiQdqFq0o1z") %>
                <br />
--%>                <input type="submit" value="Post comment" />
            </div>
            <div class="clear"></div>
    <% } %>


