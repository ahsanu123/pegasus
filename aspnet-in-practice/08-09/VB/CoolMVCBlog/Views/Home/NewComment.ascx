<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of CoolMvcBlog.Comment)" %>

    <% Html.EnableClientValidation() %>
    <% Using Html.BeginForm()%>
        <%: Html.ValidationSummary("There's something wrong with your comment:") %>
                        
            <div class="editor-label">
                <%: Html.LabelFor(Function(model) model.Author)%>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(Function(model) model.Author)%>
                <%: Html.ValidationMessageFor(Function(model) model.Author, "*")%>
            </div>
            <div class="clear"></div>
            
            <div class="editor-label">
                <%: Html.LabelFor(Function(model) model.Email)%>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(Function(model) model.Email)%>
                <%: Html.ValidationMessageFor(Function(model) model.Email, "*")%>
            </div>
            <div class="clear"></div>

            <div class="editor-label">
                <%: Html.LabelFor(Function(model) model.WebSite)%>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(Function(model) model.WebSite)%>
                <%: Html.ValidationMessageFor(Function(model) model.WebSite, "*")%>
            </div>
            <div class="clear"></div>

            <div class="editor-label">
                <%: Html.LabelFor(Function(model) model.Text)%>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(Function(model) model.Text)%>
                <%: Html.ValidationMessageFor(Function(model) model.Text, "*")%>
            </div>
            <div class="clear"></div>

            <div class="editor-label">&nbsp;</div>
            <div class="editor-field">
                <input type="submit" value="Post comment" />
            </div>
            <div class="clear"></div>
    <% End Using%>


