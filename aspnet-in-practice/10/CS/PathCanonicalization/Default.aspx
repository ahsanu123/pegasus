﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		Insert a path value:
		<asp:TextBox ID="PathValue" runat="server" />
		<asp:Button ID="SubmitButton" runat="server" Text="Generate!" 
			onclick="SubmitButton_Click" /><br />
		<asp:Literal ID="Results" runat="server" />
	</div>
	</form>
</body>
</html>
