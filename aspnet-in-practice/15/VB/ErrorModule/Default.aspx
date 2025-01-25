<%@ Page Language="VB" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		Enter 0
		<asp:TextBox ID="ErrorBox" runat="server" Text="0" />
		and 
		<asp:Button runat="server" Text="Give me an exception" ID="MyButton"
			onclick="MyButton_Click" />
			
			<hr />
			TODO: configure Membership and Roles API with this solution.
    </div>
    </form>
</body>
</html>
