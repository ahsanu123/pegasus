<%@ Page Language="C#" AutoEventWireup="false" CodeFile="1-4.aspx.cs" Inherits="_1_4" %>
<html>
<head>
<title>Listing 1.4</title>
</head>
<body>
	<form id="Form1" runat="server">
		<div>
			<asp:literal id="ResponseText" runat="server" />
			<br />
			Enter your name:
			<asp:textbox runat="server" ID="Name" />
			<br />
			<asp:button runat="server" Text="Click Me" ID="ClickButton" OnClick="HandleSubmit" />
		</div>
	</form>
</body>
</html>