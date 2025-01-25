<%@ Page Language="VB" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		Search by customer name:
		<asp:TextBox ID="CustomerName" Text="" runat="server" />
		<asp:Button runat="server" Text="Update" />
		<hr />
		
		<asp:GridView ID="CustomerList" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomerID"
			DataSourceID="CustomerDataSource">
			<Columns>
				<asp:BoundField DataField="CustomerID" HeaderText="CustomerID" ReadOnly="True" SortExpression="CustomerID" />
				<asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
				<asp:BoundField DataField="ContactName" HeaderText="ContactName" SortExpression="ContactName" />
				<asp:BoundField DataField="ContactTitle" HeaderText="ContactTitle" SortExpression="ContactTitle" />
				<asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
				<asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
				<asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
				<asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode" />
				<asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
				<asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
				<asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax" />
			</Columns>
		</asp:GridView>

		<asp:EntityDataSource ID="CustomerDataSource" runat="server" ConnectionString="name=NorthwindEntities"
			DefaultContainerName="NorthwindEntities" EnableFlattening="False" EntitySetName="Customers">
		</asp:EntityDataSource>

		<asp:QueryExtender ID="CustomerQueryExtender" runat="server" TargetControlID="CustomerDataSource">
			<asp:MethodExpression MethodName="GetFilter">
				<asp:ControlParameter Name="customerName" ControlID="CustomerName" PropertyName="Text"
					Type="String" />
			</asp:MethodExpression>
		</asp:QueryExtender>
	</div>
	</form>
</body>
</html>
<script runat="server" Language="VB">
Public Shared Function GetFilter(ByVal customers As IQueryable(Of NorthwindModel.Customer), ByVal customerName As String) As IQueryable(Of NorthwindModel.Customer)
    Return customers.Where(Function(c) c.CompanyName.Contains(customerName))
End Function
</script>
