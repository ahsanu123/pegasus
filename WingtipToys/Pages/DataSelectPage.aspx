<%@ Page 
    Title="Data Select Page" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="DataSelectPage.aspx.cs" 
    Inherits="WingtipToys.DataSelectPage" %>

<asp:Content 
    ID="BodyContent" 
    ContentPlaceHolderID="MainContent" 
    runat="server">

    <h3> Data Select Page </h3> 

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
