<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<CoolMvcBlog.Models.Category>>" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="CoolMvcBlog.Models" %>
<script runat="server">
    public IEnumerable<SelectListItem> GetUnselectedItems()
    {
        var list = this.ViewData["Categories"] as IEnumerable<Category>;
        var selected = this.Model.Select(c => c.Id).ToList();
        
        return new SelectList(list.Where(c => !selected.Contains(c.Id)), "Id", "Description");
    }
    
    public IEnumerable<SelectListItem> GetSelectedItems()
    {
        var list = this.ViewData["Categories"] as IEnumerable<Category>;
        var selected = this.Model.Select(c => c.Id).ToList();
        
        return new SelectList(list.Where(c => selected.Contains(c.Id)), "Id", "Description");
    }

    public string GetValue()
    {
        bool isFirst = true;
        StringBuilder res = new StringBuilder();
        
        foreach (var item in this.GetSelectedItems())
        {
            if (!isFirst)
                res.Append(";");

            res.Append(item.Value);
            isFirst = false;
        }

        return res.ToString();
    }
</script>
<div style="float: left; margin:2px"> 
    <%= Html.ListBox("unselected", this.GetUnselectedItems(), new { @class = "source" })%>
</div> 
<div style="float: left; margin:2px"> 
    <input type="button" id="moveRight" value="->" /> <br />
    <input type="button" id="moveLeft" value="<-" /> 
</div>
<div style="float: left; margin:2px"> 
    <%= Html.ListBox("selected", this.GetSelectedItems(), new { @class = "target" })%>
</div> 
<div style="clear:left"></div>
<%= Html.Hidden("values", this.GetValue(), new { @class = "hidden" })%>
<script type="text/javascript">
    $(function () {
        $('#moveRight').click(function () {
            $('.source option:selected').appendTo('.target');
            updateHiddenField();
        })
        $('#moveLeft').click(function () {
            $('.target option:selected').appendTo('.source');
            updateHiddenField();
        });
    });

    function updateHiddenField() {
        var string = '';
        $('.target option').each(function (index, item) {
            if (string != '')
                string += ';';
            string += item.value;
        });

        $('.hidden').attr('value', string);
    }
</script>