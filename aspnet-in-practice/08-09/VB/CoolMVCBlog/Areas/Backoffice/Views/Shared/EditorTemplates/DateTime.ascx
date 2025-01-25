<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<script runat="server">
    private string dateString
    {
        get 
        {
            if (this.Model == null)
                return null;

            return ((DateTime)this.Model).ToShortDateString();
        }
    }
</script>
<%= Html.TextBox("", dateString, new { @class = "dateInput" })%>