<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<ul>
			<li>Browser:
				<%=Request.Browser.Browser %></li>
			<li>IsMobileDevice:
				<%=Request.Browser.IsMobileDevice %></li>
			<li>Platform:
				<%=Request.Browser.Platform %></li>
			<li>IsIPhone:
				<%=(Request.Browser["IsIPhone"] as string)%></li>
			<li>Tables:
				<%=Request.Browser["tables"]%></li>
			<li>SupportsRedirectWithCookie:
				<%=Request.Browser["supportsRedirectWithCookie"]%></li>
			<li>Cookies:
				<%=Request.Browser["cookies"]%></li>
			<li>ECMAScriptVersion:
				<%=Request.Browser["ecmascriptversion"]%></li>
			<li>W3CDOMVersion:
				<%=Request.Browser["w3cdomversion"]%></li>
			<li>JScriptVersion:
				<%=Request.Browser["jscriptversion"]%></li>
		</ul>
	</div>
	</form>
</body>
</html>
