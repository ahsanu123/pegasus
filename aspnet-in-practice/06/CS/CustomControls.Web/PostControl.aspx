<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostControl.aspx.cs" Inherits="CustomControls.Web.PostControlPage" %>
<%@ Register TagPrefix="controls" Namespace="CustomControls.Composite" Assembly="CustomControls.Composite" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<controls:PostControl id="DateView" runat="server" OnValueChanged="GetValueFromPostBack" />

		<asp:Literal ID="Feedback" runat="server" />
	</div>
	</form>
</body>
</html>
