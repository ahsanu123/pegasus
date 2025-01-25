<%@ Control Language="VB" CodeBehind="ForeignKey.ascx.vb" Inherits="ASPNET4InPractice.DynamicData.ForeignKeyFilter" %>

<asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="True" CssClass="DDFilter"
    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    <asp:ListItem Text="All" Value="" />
</asp:DropDownList>

