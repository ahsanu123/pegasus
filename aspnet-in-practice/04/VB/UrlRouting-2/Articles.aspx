<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Articles.aspx.vb" Inherits="Articles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<h1>This is a rewritten page</h1>
		<p>ID:
			<asp:Label ID="IDValue" runat="server" /></p>
		<p>Description:
			<asp:Label ID="DescriptionValue" runat="server" /></p>
		<p><asp:HyperLink runat="server" ID="RoutedLink" runat="server" Text="Routed link generated in code" /></p>
		
		<p><asp:HyperLink runat="server" ID="RoutedLink2" runat="server" Text="Routed link generated in markup" NavigateUrl="<%$ RouteUrl:RouteName=ArticleRoute,id=5 %>" /></p>
	</div>
	</form>
</body>
</html>
