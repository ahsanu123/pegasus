<%@ Control Language="C#" CodeBehind="Phone.ascx.cs" Inherits="ASPNET4InPractice.DynamicData.PhoneField" %>

<asp:HyperLink ID="HyperLinkUrl" runat="server" Text="<%# FieldValueString %>" Target="_blank" />