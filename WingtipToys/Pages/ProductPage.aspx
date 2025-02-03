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
            ItemType="WingtipToys.Models.Product"
            SelectMethod="GetProductData"
            runat="server">

            <ItemTemplate>
                <controls:ProductCard 
                    Product='<%# Item %>'
                    runat="server"/>
            </ItemTemplate>

        </asp:Repeater>
    </div>

</asp:Content>
