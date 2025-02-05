<%@ Control 
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="ProductList.ascx.cs"
    Inherits="WingtipToys.CustomControl.ProductList" %>

<h2>
Product List
</h2>

<asp:Label 
    ID="DebugLabel"
    runat="server"/>

<asp:Repeater
    ID="MainRepeater"
    OnItemCommand="MainRepeater_ItemCommand"
    OnItemDataBound="MainRepeater_ItemDataBound"
    ItemType="WingtipToys.Models.Product"
    runat="server">

    <ItemTemplate>
        <asp:Panel
            ID="PanelPreview"
            runat="server">

            <controls:ProductCard 
                Product="<%# Item %>"
                runat="server"/>

            <asp:Button 
                CommandName="Edit"
                CommandArgument="<%# Item.Id %>"
                Text="Edit"
                runat="server"/>
            <asp:Button 
                CommandName="Delete"
                CommandArgument="<%# Item.Id %>"
                Text="Delete"
                runat="server"/>

        </asp:Panel>

        <asp:Panel
            ID="PanelEdit"
            runat="server">

            <p>Edit</p>

        </asp:Panel>
    </ItemTemplate>

</asp:Repeater>

