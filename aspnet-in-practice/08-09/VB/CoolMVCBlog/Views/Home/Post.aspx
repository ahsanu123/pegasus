<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of CoolMvcBlog.Post)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    CoolMvcBlog -
    <%: Me.Model.Title%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <h2>
            <%: Me.Model.Title%></h2>
        <div>
            <%: Me.Model.Text%>
        </div>
        <div class="comments">
            <% If Me.Model.Comments.Count = 0 Then%>
            <div class="comment"><i>No comments posted yet...</i></div>
            <% End If%>
            <%  For Each comment In Me.Model.Comments
                    Html.RenderPartial("Comment", comment)
                Next
               
                Html.RenderPartial("NewComment", New CoolMvcBlog.Comment())%>
        </div>
    </div>
</asp:Content>
