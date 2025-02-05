<%@ Page 
    Title="About" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="ProductPage.aspx.cs" 
    Inherits="WingtipToys.ProductPage" %>


<asp:Content 
    ID="BodyContent" 
    ContentPlaceHolderID="MainContent" 
    runat="server">

    <h2>
      Product  page
    </h2>   

    <asp:Button
        OnClick="HandleOnAddProduct"
        Text="Add Product"
        runat="server"/> 
    <hr />

    <div class="product-container">
        <asp:Repeater
            ID="ProductRepeater"
            ItemType="WingtipToys.Models.Product"
            OnItemDataBound="ProductRepeaterOnItemDataBound"
            runat="server">

            <ItemTemplate>
                <controls:TwoWayProductCard 
                    ID="twoWayProductCard"
                    Product="<%# Item %>"
                    runat="server"/>
            </ItemTemplate>

        </asp:Repeater>
    </div>


</asp:Content>
