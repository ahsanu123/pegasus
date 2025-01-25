<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CoolMvcBlog.Models.Comment>" %>
<div class="comment">
    <h2>Comment from
        <%if (!string.IsNullOrEmpty(this.Model.WebSite))
          { %>
        <a href="<%: this.Model.WebSite %>">
            <%: this.Model.Author%></a>
        <% }
          else
          {%>
        <%: this.Model.Author%>
        <% } %>
        posted on <%: this.Model.Date.ToShortDateString() %>

    </h2>
    <div>
        <%: this.Model.Text %></div>
</div>
