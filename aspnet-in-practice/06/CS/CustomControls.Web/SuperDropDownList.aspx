<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuperDropDownList.aspx.cs" Inherits="CustomControls.Web.SuperDropDownList" %>
<%@ Register TagPrefix="controls" Namespace="CustomControls.Composite" Assembly="CustomControls.Composite" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<controls:SuperDropDownList ID="Countries" runat="server" Description="Select your country" AutoPostBack="true" />
		<p>Selected country: <%= Countries.SelectedValue %></p>
	</div>
	</form>
</body>
</html>
