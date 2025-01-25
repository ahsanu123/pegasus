<%@ Control 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="ViewSwitcher.ascx.cs" 
    Inherits="WingtipToys.ViewSwitcher" %>

<div id="viewSwitcher">
    <%: CurrentView %> view | <a href="<%: SwitchUrl %>" data-ajax="false">Switch to <%: AlternateView %></a>
</div>
<asp:Label runat="server" ID="ViewLabel"></asp:Label>
<asp:Label runat="server" ID="SecondLabel"></asp:Label>
