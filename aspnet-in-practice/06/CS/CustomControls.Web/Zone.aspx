<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Zone.aspx.cs" Inherits="CustomControls.Web.Zone" %>

<%@ Register TagPrefix="controls" Namespace="CustomControls.ControlBuilders" Assembly="CustomControls.ControlBuilders" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>

	<controls:Zone runat="server">
		<box title="First box">
			<articles PageSize="10" Category="ASP.NET" />
		</box>
		
		<box title="Second box">
			<articles PageSize="5" Category="Silverlight" />
		</box>
		
		<p>Test: I'm a plain HTML markup</p>

	</controls:Zone>

</body>
</html>