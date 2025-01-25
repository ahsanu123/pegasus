<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<asp:Panel ID="LiveID" runat="server" BorderColor="Gray" BackColor="LightGray">
			<p><strong>Attention:</strong> to use your Windows Live ID, you have to first login. If you do not have an account, you have to create a new one.</p>
		</asp:Panel>
	
		<asp:LoginView runat="server">
			<AnonymousTemplate>
				<asp:Login ID="Login1" runat="server" />
				<hr />
				Windows LIVE ID: <iframe src="http://login.live.com/controls/WebAuth.htm?mkt=en-us&amp;appid=<%=AppID%>&context=<%=Server.UrlEncode(Request["ReturnUrl"])%>&style=font-size%3A+10pt%3B+font-family%3A+verdana%3B+background%3A+white%3B"
					width="80px" height="20px" marginwidth="0" marginheight="0" align="middle" frameborder="0"
					scrolling="no" style="border-style: hidden; border-width: 0"></iframe>
				<hr />
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
