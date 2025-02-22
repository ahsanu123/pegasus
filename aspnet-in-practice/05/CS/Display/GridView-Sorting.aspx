﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridView-Sorting.aspx.cs" Inherits="GridView_Sorting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sorting</title>
	<link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    	<asp:GridView ID="CustomerView" runat="server" 
		     AutoGenerateEditButton="true"
		     AutoGenerateDeleteButton="true"
		     AllowPaging="true"
		     AllowSorting="true"
			 SortedAscendingHeaderStyle-CssClass="sortedAsc"
  			 SortedDescendingHeaderStyle-CssClass="sortedDesc"
			 SortedAscendingCellStyle-CssClass="sortdeCellAsc"
			 SortedDescendingCellStyle-CssClass="sortedCellDesc"
		     DataKeyNames="CustomerID"
		     DataSourceID="CustomerSource" />

		<asp:EntityDataSource ID="CustomerSource" runat="server" 
		    ConnectionString="name=NorthwindEntities"
		    DefaultContainerName="NorthwindEntities"
		    EnableInsert="true" EnableDelete="true" EnableUpdate="true"
		    EntitySetName="Customers" />
    </div>
    </form>
</body>
</html>
