<%@ Page Language="VB" AutoEventWireup="true" Inherits="Cache.CachePage" Codebehind="Cache.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<p>Cached Imports <asp:Literal ID="ProviderName" runat="server" /></p>
		<asp:GridView runat="server" ID="CustomerList" />
	</div>
	</form>
</body>
</html>
