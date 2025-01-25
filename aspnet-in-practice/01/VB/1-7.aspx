<%@ Page Language="VB" AutoEventWireup="false" CodeFile="1-7.aspx.vb" Inherits="_1_7" %>
<html>
<head>
<title>Listing 1.7</title>
</head>
<body>
	<form id="Form1" runat="server">
		<div>
        	<asp:Placeholder id="FormContainer" runat="server">
				<p>
					Your first name:
					<asp:textbox runat="server" ID="FirstName" />
					<br />

					Your last name:
					<asp:textbox runat="server" ID="LastName" />
					<br />

					Your country:
					<asp:DropDownList runat="server" id="Country">
						<asp:ListItem value="IT">Italy</asp:ListItem>
						<asp:ListItem value="UK">UK</asp:ListItem>
						<asp:ListItem value="USA">USA</asp:ListItem>
					</asp:DropDownList>
					<br />

					<asp:button runat="server" Text="Next" ID="ClickButton" OnClick="HandleSubmit" />
				</p>		
			</asp:Placeholder>
			
			<asp:Placeholder id="FormResponse" runat="server" Visible="false">
				<asp:literal id="ResponseText" runat="server" />
			</asp:Placeholder>
		</div>
	</form>
</body>
</html>