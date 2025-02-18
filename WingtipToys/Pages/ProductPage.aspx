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
    <asp:Label 
        ID="DebugLabel"
        runat="server"/>

    <asp:Button
        OnClick="HandleOnAddProduct"
        Text="Add Product"
        runat="server"/> 
    <hr />

    <asp:UpdatePanel
        ID="Updatepanel"
        runat="server">

        <ContentTemplate>
            <asp:Repeater 
                ID="MainRepeater"
                OnItemDataBound="ProductRepeaterOnItemDataBound"
                ItemType="WingtipToys.Models.Product"
                runat="server">

                <ItemTemplate>
                    <controls:ProductCard 
                        Product="<%# Item %>"
                        runat="server"/>
                </ItemTemplate>

            </asp:Repeater>
<%--            <controls:ProductList 
                ID="ProductList"
                runat="server"/>--%>
        </ContentTemplate>

    </asp:UpdatePanel>

    <div class="product-container">
<%--        <asp:Repeater
            ID="ProductRepeater"
            ItemType="WingtipToys.Models.Product"
            OnItemDataBound="ProductRepeaterOnItemDataBound"
            runat="server">

            <ItemTemplate>
                <controls:TwoWayProductCard 
                    ID="twoWayProduct"Card"
                    Product="<%# Item %>"
                    runat="server"/>
            </ItemTemplate>

        </asp:Repeater>--%>
    </div>


</asp:Content>
