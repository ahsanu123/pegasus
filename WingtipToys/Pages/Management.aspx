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

    <h2>Management Page</h2>
    
    <wing:ProductTable  runat="server">
        <Template>
            <p>template content</p>
        </Template>
    </wing:ProductTable>


</asp:Content>


