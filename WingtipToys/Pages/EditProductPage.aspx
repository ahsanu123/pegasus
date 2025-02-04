<%@ Page 
    Title="About" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="EditProductPage.aspx.cs" 
    Inherits="WingtipToys.EditProductPage" %>

<asp:Content 
    ID="BodyContent" 
    ContentPlaceHolderID="MainContent" 
    runat="server">

  <h2>
    Edit Product Page
  </h2>   

    <asp:FormView
        SelectMethod="formview_GetItem"
        ItemType="WingtipToys.Models.Product"
        ID="formview"
        runat="server">

        <ItemTemplate>
            <p>item template</p>
        </ItemTemplate>

        <EditItemTemplate>
            <p>Edit Template</p>
        </EditItemTemplate>

    </asp:FormView>

    <asp:repeater
        selectmethod="getproductform"
        itemtype="System.String"
        runat="server">

        <itemtemplate>
            <label>
                <b><%# Item%></b>
            </label>

            <input 
                name="<%# Item%>"
                type="text" />
        </itemtemplate>

    </asp:repeater>
    
    <div>
        <button type="submit">
            Update Product
        </button>
    </div>

    <asp:FormView
        SelectMethod="GetId"
        ItemType="System.String"
        runat="server">

        <ItemTemplate>
            <%# Item %>
        </ItemTemplate>
    </asp:FormView>

</asp:Content>
