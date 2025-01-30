<%@ Register
    Src="~/Component/ProductTable.ascx"
    TagPrefix="wing"
    TagName="ProductTable"
    %>

<%@ Page 
    Async="true"
    Title="Management"
    Language="C#" 
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master" 
    CodeBehind="Management.aspx.cs" 
    Inherits="WingtipToys.Pages.Management" %>

<asp:Content 
    ID="BodyContent" 
    ContentPlaceHolderID="MainContent" 
    runat="server">

    <div class="product-management-page">

        <h2>Management Page</h2>
        
        <asp:FormView
            name="ProductListView"
            ItemType="WingtipToys.Models.Product"
            DataKeyNames="Id"
            SelectMethod="GetData"
            UpdateMethod="UpdateData"
            InsertMethod="InsertData"
            DeleteMethod="DeleteData"
            runat="server">

            <HeaderTemplate>
                <div class="header">
                    <asp:Button 
                        CommandName="New"
                        Text="➕ Add Product"
                        runat="server"/>
                    <asp:Button 
                        CommandName="Delete"
                        Text="➕ Add Product"
                        runat="server"/>
                    <asp:Button 
                        CommandName="New"
                        Text="➕ Add Product"
                        runat="server"/>
                </div>
            </HeaderTemplate>

        </asp:FormView>

        <asp:ListView
            DataKeyNames="Id"
            ItemType="WingtipToys.Models.Product"
            SelectMethod="ListViewGetData"
            UpdateMethod="ListViewUpdateItem"
            DeleteMethod="ListViewDeleteItem"
            runat="server">

            <EmptyDataTemplate>
                <b>No Data To show</b>
            </EmptyDataTemplate>

            <InsertItemTemplate>

            </InsertItemTemplate>

            <ItemTemplate>
                <div>
                    <p><%#: Item.Name %></p>
                    <p><%#: Item.UnitPrice %></p>
                    <p><%#: Item.Description %></p>
                </div>
            </ItemTemplate>

        </asp:ListView>
        
    </div>

</asp:Content>


