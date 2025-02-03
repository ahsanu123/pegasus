<%@ Page 
    Title="Home Controller" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content 
    ID="BodyContent" 
    ContentPlaceHolderID="MainContent" 
    runat="server">

     <h2><%= Html.Encode(ViewData["Message"]) %></h2>

</asp:Content>
