<%@ Page Language="VB" AutoEventWireup="true" CodeFile="CustomerList.aspx.vb" Inherits="CustomerList" %>
<%@ Import Namespace="ObjectModel" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Databinding</title>
	<link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
	<asp:Repeater id="CustomerView" runat="server">
	  <HeaderTemplate>
	    <ul>
	  </HeaderTemplate>
	  <FooterTemplate>
	    </ul>
	  </FooterTemplate>
	  <ItemTemplate>
	   <li><%#DirectCast(Container.DataItem,Customer).ContactName %></li>
	  </ItemTemplate>
	</asp:Repeater>

    </div>
    </form>
</body>
</html>
