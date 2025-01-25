<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DropDownList.aspx.cs" Inherits="_DropDownList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Choose a category:<br />
        <asp:DropDownList runat="server" ID="ProductsList" AutoPostBack="true">
            <asp:ListItem OptionGroup="Milk and dairy product">Yogurt</asp:ListItem>
            <asp:ListItem OptionGroup="Milk and dairy product">Butter</asp:ListItem>
            <asp:ListItem OptionGroup="Milk and dairy product">Cheese</asp:ListItem>
            <asp:ListItem OptionGroup="Milk and dairy product">Milk</asp:ListItem>
            <asp:ListItem OptionGroup="Eggs">Eggs</asp:ListItem>
            <asp:ListItem OptionGroup="Meat">Beef</asp:ListItem>
            <asp:ListItem OptionGroup="Meat">Chicken</asp:ListItem>
            <asp:ListItem OptionGroup="Meat">Pork</asp:ListItem>
            <asp:ListItem OptionGroup="Bread & wheat">Bread</asp:ListItem>
            <asp:ListItem OptionGroup="Bread & wheat">Biscuits</asp:ListItem>
            <asp:ListItem OptionGroup="Bread & wheat">Pasta</asp:ListItem>
            <asp:ListItem OptionGroup="Fish">Fish</asp:ListItem>
            <asp:ListItem OptionGroup="Nuts">Peanuts</asp:ListItem>
            <asp:ListItem OptionGroup="Nuts">Tree nuts (walnuts)</asp:ListItem>
            <asp:ListItem OptionGroup="Soy">Soy</asp:ListItem>
            <asp:ListItem OptionGroup="Other">Other</asp:ListItem>
        </asp:DropDownList>

        <br />
        Selected value:
        <asp:Literal ID="SelectedValue" runat="server" />

        <hr />
        DropDownList without optgroup:
        <asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="true">
            <asp:ListItem>Yogurt</asp:ListItem>
            <asp:ListItem>Butter</asp:ListItem>
            <asp:ListItem>Soy</asp:ListItem>
        </asp:DropDownList>
    </div>
    </form>
</body>
</html>
