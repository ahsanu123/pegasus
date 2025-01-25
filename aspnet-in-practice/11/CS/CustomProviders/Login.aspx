<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:LoginView runat="server">
		<AnonymousTemplate>
			<asp:Login ID="Login1" runat="server" />
			<p>
				<a href="CreateUser.aspx">Create a new user</a><br />
				<a href="GetPassword.aspx">Get Password</a>
			</p>
		</AnonymousTemplate>
		<LoggedInTemplate>
			We're sorry, the page you requested is not available to your role.
		</LoggedInTemplate>
	</asp:LoginView>
    
    </div>
    </form>
</body>
</html>
