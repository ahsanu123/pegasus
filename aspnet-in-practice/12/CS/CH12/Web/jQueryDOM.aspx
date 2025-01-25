<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jQueryDOM.aspx.cs" Inherits="jQueryDOM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script type="text/javascript">
		function checkOptions() {
			alert($(document).find("span").size());
			var result = "";
			$("#checkContainer").find(":checkboxspan").each(function (item) {
				result += this.innerHTML + "\r\n";
			});

			$(":checkbox:checked").next("span").each(function (item) {
				result += this.innerHTML + "\r\n";
			});
			alert(result);
		}

		function f() {
			alert($("#tree").find("li").size());
		}
		$(function () {
			alert("Page loaded");
			$("#tree li:first > ul").append($("<li>").html("last node"));
			alert(0);
			$("#tree li:first > ul > li:last").remove();
			alert("Page loaded");
		});
	</script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
			<div id="checkContainer">
				<input type="checkbox" /><span>Option 1</span><br />
				<input type="checkbox" /><span>Option 2</span><br />
				<input type="checkbox" /><span>Option 3</span><br />
				<input type="checkbox" /><span>Option 4</span><br />
				<input type="checkbox" /><span>Option 5</span><br />
				<input type="checkbox" /><span>Option 6</span><br />
				<input type="checkbox" /><span>Option 7</span><br />
				<input type="button" value="check" onclick="checkOptions()" />
			</div>
			<div>
				<ul id="tree">
					<li>Node1
						<ul>
							<li>Subnode1</li>
							<li>Subnode2</li>
						</ul>
					</li>
					<li>Node2
						<ul>
							<li>Subnode1</li>
							<li>Subnode2</li>
						</ul>
					</li>
				</ul>
				<input type="button" onclick="f()" />
			</div>
    </form>
</body>
</html>
