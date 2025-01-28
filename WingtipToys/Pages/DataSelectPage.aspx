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

    <controls:ProductCard 
        Name="Hell"
        runat="server"/>


</asp:Content>
