<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Good.aspx.cs" Inherits="Good" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Enter something: <asp:TextBox ID="SomeText" runat="server" />
    <asp:Button ID="SomeButton" runat="server" Text="Submit!" 
			onclick="SomeButton_Click" />
	<hr />
    <asp:Literal ID="Results" runat="server" />
    </div>
    </form>
</body>
</html>
