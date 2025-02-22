﻿<%@ Page Language="VB" AutoEventWireup="true" Inherits="Chapter15.ParallelFX.Results" Codebehind="Results.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:PlaceHolder ID="WaitingPanel" runat="server" Visible="false">
			Please wait...
		</asp:PlaceHolder>
    
		<asp:PlaceHolder ID="ResultsPanel" runat="server" Visible="false">
			<h1>Results</h1>
			
			<asp:literal ID="Feedback" runat="server" />
			
			<asp:GridView ID="ResultList" runat="server" />
		</asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
