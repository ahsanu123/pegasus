<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jQueryUI.aspx.cs" Inherits="jQueryUI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<script src="Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
	<script src="Scripts/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
	<link href="css/ui-lightness/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript">
		$(function () {
			$("#CustomerName").autocomplete({
				source: "RestService.svc/GetCustomers",
				minLength: 1
			});
			$("#CustomerName").datepicker({ minDate: new Date(), maxDate: "+10D",
				monthNames: ["Gen", "Feb", "Mar", "Apr", "Mag", "Giu", "Lug", "Ago", "Set", "Ott", "Nov", "Dec"],
				dateFormat: "dd/mm/yy"
			});
			$("#tabs").tabs();
			$("#Save").click(function () {
				$("#dialog").dialog("open");
			});
			$("#dialog").dialog({ title: "confirmation", modal: true, autoOpen: false, buttons: { Yes: Yes_Click, No: No_Click} });
		});

		function Yes_Click(ev){
			$("#dialog").dialog("close");
		}

		function No_Click(ev) {
			$("#dialog").dialog("close");
		}
	</script>
</head>
<body>
	<form id="form1" runat="server">
		<div id="tabs">
			<ul>
				<li><a href="#orderData">order</a></li>
				<li<a href="#details">details</a></li>
			</ul>
			<div id="orderData">
				<asp:TextBox runat="server" id="CustomerName" ClientIDMode="Static" />
			</div>
			<div id="details">Details</div>
		</div>
		<div id="dialog">Are you sure you want to save?</div>
		<input type="button" id="Save" value="Save" />
	</form>
</body>
</html>