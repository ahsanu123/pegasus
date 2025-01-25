<%@ Control Language="VB" CodeBehind="ForeignKey.ascx.vb" Inherits="ASPNET4InPractice.DynamicData.ForeignKeyField" %>

<asp:HyperLink ID="HyperLink1" runat="server"
    Text="<%# GetDisplayString() %>"
    NavigateUrl="<%# GetNavigateUrl() %>"  />

