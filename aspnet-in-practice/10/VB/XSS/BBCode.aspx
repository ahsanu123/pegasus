<%@ Page Language="VB" AutoEventWireup="true" CodeFile="BBCode.aspx.vb" Inherits="BBCode" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		Your Text:
		<asp:TextBox ID="SomeText" runat="server" TextMode="MultiLine" Rows="8" Columns="50" />
		<br />
		Supported markup: [b], [i], [u]
		<br />
		<asp:Button ID="SomeButton" runat="server" Text="Submit!" OnClick="SomeButton_Click" />
		<hr />
		<asp:Literal ID="Results" runat="server" />
	</div>
	</form>
</body>
</html>
