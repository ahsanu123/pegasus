<%@ Page 
    Title="Custom Event Page" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="CustomEventPage.aspx.cs" 
    Inherits="WingtipToys.CustomEventPage" %>

<asp:Content 
    ID="BodyContent" 
    ContentPlaceHolderID="MainContent" 
    runat="server">

    <h3>Custom Event Button</h3>

    <controls:CustomPostBackButton 
        id="DateView" 
        runat="server" 
        OnValueChanged="GetValueFromPostBack" />

    <controls:CustomFormView runat="server">
    </controls:CustomFormView>

    <asp:Literal ID="Feedback" runat="server" />

</asp:Content>
