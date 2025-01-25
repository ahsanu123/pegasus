<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of IEnumerable(Of CoolMvcBlog.Category))" %>
<%@ Import Namespace="CoolMvcBlog" %>
<%@ Import Namespace="System.Linq" %>
<script runat="server">
    Public Function GetUnselectedItems() As IEnumerable(Of SelectListItem)
        Dim list = TryCast(Me.ViewData("Categories"), IEnumerable(Of Category))
        Dim selected = Me.Model.Select(Function(c) c.Id).ToList
        
        Return New SelectList(list.Where(Function(c) Not selected.Contains(c.Id)), "Id", "Description")
    End Function
    
    Public Function GetSelectedItems() As IEnumerable(Of SelectListItem)
        Dim list = TryCast(Me.ViewData("Categories"), IEnumerable(Of Category))
        Dim selected = Me.Model.Select(Function(c) c.Id).ToList
        
        Return New SelectList(list.Where(Function(c) selected.Contains(c.Id)), "Id", "Description")
    End Function

    Public Function GetValue() As String
        Dim isFirst = True
        Dim res As New StringBuilder()
        
        For Each item In Me.GetSelectedItems()
            If Not isFirst Then
                res.Append(";")
            End If
            
            res.Append(item.Value)
            isFirst = False
        Next

        Return res.ToString()
    End Function
</script>
<div style="float: left; margin:2px"> 
    <%= Html.ListBox("unselected", Me.GetUnselectedItems(), New With {.class = "source"})%>
</div> 
<div style="float: left; margin:2px"> 
    <input type="button" id="moveRight" value="->" /> <br />
    <input type="button" id="moveLeft" value="<-" /> 
</div>
<div style="float: left; margin:2px"> 
    <%= Html.ListBox("selected", Me.GetSelectedItems(), New With {.class = "target"})%>
</div> 
<div style="clear:left"></div>
<%= Html.Hidden("values", Me.GetValue(), New With {.class = "hidden"})%>
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