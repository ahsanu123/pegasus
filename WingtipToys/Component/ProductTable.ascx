<%@ Control 
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="ProductTable.ascx.cs"
    Inherits="WingtipToys.ProductTable" %>

<h4>Products</h4>
<asp:Button
    runat="server"
    OnClick="HandleOnAdd"
    Text="➕ Add" />

<asp:PlaceHolder
    runat="server"
    ID="TemplatePlaceholder" />

<asp:ListView 
    runat="server"
    ID="ProductListView"
    ItemType="WingtipToys.Models.Product">

    <LayoutTemplate>
      <table>
        <tr runat="server">
          <th runat="server">Id</th>
          <th runat="server">Name</th>
          <th runat="server">Description</th>
          <th runat="server">Unit Price</th>
          <th runat="server">Action</th>
        </tr>

        <tr runat="server" id="itemPlaceholder" />

      </table>

    </LayoutTemplate>

    <ItemTemplate>
        <tr runat="server">
            <td>
                <%#: Item.Id%>
            </td>
            <td>
                <%#: Item.Name %>
            </td>
            <td>
                <%#: Item.Description %>
            </td>
            <td>
                <%#: Item.UnitPrice %>
            </td>
            <td>
                <asp:Button 
                    runat="server"
                    OnClick="HandleOnEdit"
                    Text="✏️ Edit"/>
                <asp:Button 
                    runat="server"
                    OnClick="HandleOnDelete"
                    CommandArgument="<%# Item.Id %>"
                    Text="❌ Delete"/>
            </td>
        </tr>
    </ItemTemplate>

    <EmptyDataTemplate>
        <b>No Data Was Found</b>
    </EmptyDataTemplate>
    
    <EmptyItemTemplate>
        <b>Item Is Empty</b>
    </EmptyItemTemplate>

</asp:ListView>
