<%@ Control Language="VB" CodeBehind="Children.ascx.vb" Inherits="ASPNET4InPractice.DynamicData.ChildrenField" %>

<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="<%# GetChildrenPath() %>" />

