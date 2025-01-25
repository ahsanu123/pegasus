<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jQueryAjax.aspx.cs" Inherits="jQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<script src="Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
	<script type="text/javascript">
		$(function () {
			$("#btnSimple").click(function () {
				$.post('RestService.svc/GetData', {}, function (result) {
					alert(result.d.Date);
				}, "json");
				return false;
			});

			$("#btnWithParams").click(function () {
				$.ajax({
					url: "RestService.svc/GetOrdersAmount",
					data: '{ "CustomerId": "ALFKI" }',
					type: "POST",
					contentType: "application/json",
					dataType: "json",
					success: function (result) {
						alert(result.d);
					}
				}); 
				return false;
			});

			$("#btnLoad").click(function () {
				$("#spanLoad").load("loadedPage.aspx");
				return false;
			});

			$("#btnPageMethod").click(function () {
				$.ajax({
					url: "jQueryAjax.aspx/GetOrdersAmount",
					data: '{ "CustomerId": "ALFKI" }',
					type: "POST",
					contentType: "application/json",
					dataType: "json",
					success: function (result) {
						alert(result.d);
					}
				});
				return false;
			});
		});
	</script>
	<title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
			<asp:Button ID="btnSimple" runat="server"  Text="Post simple"></asp:Button>
			<span id="spanSimple"></span>
			<br />
			<asp:Button ID="btnPageMethod" runat="server" Text="PageMethod"></asp:Button>
			<span id="spanPageMethod"></span>
			<br />
			<asp:Button ID="btnWithParams" runat="server" Text="Post with params"></asp:Button>
			<span id="spanWithParams"></span>
			<br />
			<asp:Button ID="btnLoad" runat="server" Text="Load"></asp:Button>
			<span id="spanLoad"></span>
    </div>
    </form>
</body>
</html>
