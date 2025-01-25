<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SingleView.aspx.cs" Inherits="CustomControls.Web.SingleView" %>
<%@ Register TagPrefix="controls" Namespace="CustomControls.Databinding" Assembly="CustomControls.Databinding" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<controls:SingleView runat="server" ID="AuthorView">
			<ItemTemplate>
				<p><%#Eval("FirstName") %>
					<%#Eval("LastName") %></p>
			</ItemTemplate>
			<EmptyTemplate>
				<p>No author specified.</p>
			</EmptyTemplate>
		</controls:SingleView>
	</div>
	</form>
</body>
</html>