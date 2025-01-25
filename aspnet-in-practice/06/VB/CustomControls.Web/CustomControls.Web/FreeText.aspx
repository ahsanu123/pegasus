<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="~/FreeText.aspx.vb" Inherits="CustomControls.Web.FreeText" %>
<%@ Register TagPrefix="controls" Namespace="CustomControls.Composite" Assembly="CustomControls.Composite" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<br /><br />
		<controls:FreeText runat="server" Text="This is a test" />
	</div>
	</form>
</body>
</html>
