<%@ Page Language="VB" AutoEventWireup="true" Inherits="Cache.MemoryCache_ChangeMonitor" Codebehind="MemoryCache-ChangeMonitor.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<p>Saved! Try to change file.txt</p>

		<asp:Literal ID="Value" runat="server" />
	</div>
	</form>
</body>
</html>
