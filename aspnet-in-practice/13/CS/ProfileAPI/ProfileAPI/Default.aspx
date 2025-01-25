<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProfileAPI.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<h1>Welcome <%=Profile.FirstName %></h1>

	<div>
		First Name:
		<asp:TextBox ID="FirstName" runat="server" /><br />
		Birth Day:
		<asp:TextBox ID="BirthDay" runat="server" /><br />

		<asp:Button runat="server" Text="Update Profile" onclick="Unnamed1_Click" />
	</div>
	</form>
</body>
</html>
