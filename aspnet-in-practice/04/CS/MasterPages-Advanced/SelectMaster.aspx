﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectMaster.aspx.cs" Inherits="SelectMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p>Select you Master Page from here:</p>
        <p><asp:DropDownList ID="MasterList" runat="server" /></p>
        <p><asp:Button ID="ConfirmButton" Text="Confirm" runat="server" OnClick="SaveMasterPage" /></p>
    </div>
    </form>
</body>
</html>
