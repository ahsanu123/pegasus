<%@ Page 
    Title="About" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="CreateProductPage.aspx.cs" 
    Inherits="WingtipToys.CreateProductPage" %>

<asp:Content 
    ID="BodyContent" 
    ContentPlaceHolderID="MainContent" 
    runat="server">

  <h2>
    Create  Product  page
  </h2>   

    <asp:Repeater
        SelectMethod="GetProductForm"
        ItemType="System.String"
        runat="server">

        <ItemTemplate>
            <label>
                <b><%# Item %></b>
            </label>

            <input 
                name="<%# Item %>"
                type="text" />
        </ItemTemplate>

    </asp:Repeater>

    <div>
        <button type="submit">
            Create Product
        </button>
    </div>

    <asp:Label
        ID="debugBox"
        runat="server">
    </asp:Label>

    <asp:FormView
        ItemType="WingtipToys.Models.Product"
        SelectMethod="GetProduct"
        runat="server">
        <ItemTemplate>
            <p><%#  Item.Name %></p>
            <p><%#  Item.UnitPrice %></p>
            <p><%#  Item.Description %></p>
        </ItemTemplate>

    </asp:FormView>

</asp:Content>
