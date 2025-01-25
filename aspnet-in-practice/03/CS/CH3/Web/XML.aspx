<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XML.aspx.cs" Inherits="XML" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:button runat="server" ID="btnCreate" Text="Create" OnClick="btnCreate_Click"></asp:button>
    <asp:button runat="server" ID="btnCreateFromDB" Text="CreateFromDB" OnClick="btnCreateFromDB_Click"></asp:button>
    <asp:button runat="server" ID="btnFilter" Text="Filter" OnClick="btnFilter_Click"></asp:button>
    <asp:button runat="server" ID="btnSort" Text="Sort" OnClick="btnSort_Click"></asp:button>
    <br />
		<asp:TextBox runat="server" ID="txt" TextMode="MultiLine" Rows="20" Columns="150"></asp:TextBox>
		<asp:GridView runat="server" ID="grd"></asp:GridView>
    </div>
    </form>
</body>
</html>
