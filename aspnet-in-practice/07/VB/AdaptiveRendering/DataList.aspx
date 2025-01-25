<%@ Page Language="VB" AutoEventWireup="true" CodeFile="DataList.aspx.vb" Inherits="_DataList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DataList ID="ProductList" runat="server" RepeatColumns="3" RepeatDirection="Vertical">
            <HeaderTemplate><h1>Products (Vertical)</h1></HeaderTemplate>
            <ItemTemplate><%#Container.DataItem.ToString() %></ItemTemplate>
            <FooterTemplate><hr /></FooterTemplate>
        </asp:DataList>
        
        <asp:DataList ID="ProductList2" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
            <HeaderTemplate><h1>Products (Horizontal)</h1></HeaderTemplate>
            <ItemTemplate><%#Container.DataItem.ToString() %></ItemTemplate>
            <FooterTemplate><hr /></FooterTemplate>
        </asp:DataList>
    </div>
    </form>
</body>
</html>
