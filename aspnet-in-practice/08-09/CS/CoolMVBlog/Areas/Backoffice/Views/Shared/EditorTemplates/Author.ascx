<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Nullable<int>>" %>
<%@ Import Namespace="System.Linq" %>
<script runat="server">
    public IEnumerable<SelectListItem> GetItems()
    {
        return new SelectList(this.ViewData["Authors"] as IEnumerable, 
            "Id", "Name", this.Model);
    }
</script>
<%= Html.DropDownList("", this.GetItems(), "Please select an author")%>
