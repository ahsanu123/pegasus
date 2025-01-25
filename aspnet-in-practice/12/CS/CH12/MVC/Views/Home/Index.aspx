<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Web.Mvc.Ajax" %>
<html>
	<head>
		<title></title>
		<script type="text/javascript" src="../../Scripts/jquery-1.4.1.min.js"></script>
	<script type="text/javascript">
		$(function () {
			$("#btnPageMethod").click(function () {
				$.get(
					"/home/GetOrdersAmount",
					{ CustomerId: "ALFKI" },
					function (data) {
						alert(data);
					}
				);
			});
		});


	</script>
	</head>
	<body>
		<input type="button" id="btnPageMethod" value="PageMethod" />
		<span id="spanPageMethod"></span>
	</body>
</html>