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
    ItemType="WingtipToys.Models.Product"
    runat="server">

    <ItemTemplate>
        <asp:Panel
            ID="PanelPreview"
            runat="server">

            <controls:ProductCard 
                Product="<%# Item %>"
                runat="server"/>
            <hr />

        </asp:Panel>

        <asp:Panel
            ID="PanelEdit"
            runat="server">

            <h4>Edit Mode</h4>
            <b><%#: Item.Name %></b>
            <hr />

        </asp:Panel>
    </ItemTemplate>

</asp:Repeater>

