<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of CoolMvcBlog.Comment)" %>
<div class="comment">
    <h2>Comment from
        <%If Not String.IsNullOrEmpty(Me.Model.WebSite) Then%>
        <a href="<%: Me.Model.WebSite %>"><%: Me.Model.Author%></a>
        <% Else%>
        <%: Me.Model.Author%>
        <% End If%>
        posted on <%: Me.Model.Date.ToShortDateString()%>

    </h2>
    <div>
        <%: Me.Model.Text%></div>
</div>