﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListView.aspx.cs" Inherits="CustomerList" %>
<%@ Import Namespace="ObjectModel" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Databinding</title>
	<link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
	<asp:ListView ID="CustomerView" runat="server"> 
	  <ItemTemplate> 
	    <div class="customer">
	       <%#((Customer)Container.DataItem).ContactName%>
	    </div>
	  </ItemTemplate> 
	</asp:ListView>

    </div>
    </form>
</body>
</html>
