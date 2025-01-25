<%@ Control Language="C#" CodeBehind="Children.ascx.cs" Inherits="ASPNET4InPractice.DynamicData.ChildrenField" %>

<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="<%# GetChildrenPath() %>" />

