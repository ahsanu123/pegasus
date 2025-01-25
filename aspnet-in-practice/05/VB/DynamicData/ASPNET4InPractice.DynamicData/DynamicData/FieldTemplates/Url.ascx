<%@ Control Language="VB" CodeBehind="Url.ascx.vb" Inherits="ASPNET4InPractice.DynamicData.UrlField" %>

<asp:HyperLink ID="HyperLinkUrl" runat="server" Text="<%# FieldValueString %>" Target="_blank" />

