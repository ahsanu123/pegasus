<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SimpleUpdatePanel.aspx.cs" Inherits="SimpleUpdatePanel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
			<asp:ScriptManager runat="server" />
			<asp:DropDownList runat="server" ID="Regions" AutoPostBack="true" OnSelectedIndexChanged="Regions_Changed" AppendDataBoundItems="true" DataTextField="RegionDescription" DataValueField="RegionId">
				<asp:ListItem  value="" Text="[Select a Territory]" />
			</asp:DropDownList>
			<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
				<Triggers>
					<asp:AsyncPostBackTrigger ControlID="Regions" EventName="SelectedIndexChanged" />
				</Triggers> 
				<ContentTemplate>
					<asp:DropDownList ID="Territories" runat="server" DataTextField="TerritoryDescription"></asp:DropDownList>
				</ContentTemplate>
			</asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
