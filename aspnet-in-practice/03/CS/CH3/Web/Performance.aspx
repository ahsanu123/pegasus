<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Performance.aspx.cs" Inherits="Performance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button runat="server" Text="Avoid Multiple Excecution" OnClick="AvoidMultipleExcecution_Click" />
    <asp:Button runat="server" Text="Retrieve entity by key using GetObjectByKey" OnClick="GetObjectByKey_Click" />
    </div>
    </form>
</body>
</html>
