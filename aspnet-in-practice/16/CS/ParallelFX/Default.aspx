<%@ Page Language="C#" AutoEventWireup="true" Inherits="ASPNET4InPractice.Chapter15._Default" Codebehind="Default.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		Enter a flight number:
		<asp:TextBox ID="FlightNumber" runat="server" />
    
		<asp:Button ID="StartWork" runat="server" Text="Search!" 
			onclick="StartWork_Click" />
    </div>
    </form>
</body>
</html>
