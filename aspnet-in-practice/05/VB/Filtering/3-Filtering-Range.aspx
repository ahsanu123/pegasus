<%@ Page Language="VB" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>

	Show only product with units in stock between
	<asp:TextBox ID="LowerQuantity" Text="0" runat="server" />
	and
	<asp:TextBox ID="HigherQuantity" Text="1000" runat="server" />
	<asp:Button runat="server" Text="Update" />
	<hr />

		<asp:GridView runat="server" ID="ProductList" DataSourceID="ProductDataSource" 
			AutoGenerateColumns="False" DataKeyNames="ProductID" >
			<Columns>
				<asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" 
					SortExpression="ProductID" />
				<asp:BoundField DataField="ProductName" HeaderText="ProductName" 
					SortExpression="ProductName" />
				<asp:BoundField DataField="SupplierID" HeaderText="SupplierID" 
					SortExpression="SupplierID" />
				<asp:BoundField DataField="CategoryID" HeaderText="CategoryID" 
					SortExpression="CategoryID" />
				<asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" 
					SortExpression="QuantityPerUnit" />
				<asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" 
					SortExpression="UnitPrice" />
				<asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" 
					SortExpression="UnitsInStock" />
				<asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" 
					SortExpression="UnitsOnOrder" />
				<asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel" 
					SortExpression="ReorderLevel" />
				<asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" 
					SortExpression="Discontinued" />
			</Columns>
		</asp:GridView>
	
		<asp:EntityDataSource ID="ProductDataSource" runat="server" ConnectionString="name=NorthwindEntities"
			DefaultContainerName="NorthwindEntities" EnableFlattening="False" 
			EntitySetName="Products">
		</asp:EntityDataSource>
	
		<asp:QueryExtender ID="QueryExtender1" runat="server" TargetControlID="ProductDataSource">
			<asp:RangeExpression DataField="UnitsInStock" MaxType="Inclusive" MinType="Inclusive">
				<asp:ControlParameter ControlID="LowerQuantity" PropertyName="Text" Type="Int16" />
				<asp:ControlParameter ControlID="HigherQuantity" PropertyName="Text" Type="Int16" />
			</asp:RangeExpression>
		</asp:QueryExtender>
	</div>
	</form>
</body>
</html>
