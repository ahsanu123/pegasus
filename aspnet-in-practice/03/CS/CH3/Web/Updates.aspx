<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Updates.aspx.cs" Inherits="Updates" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
			<asp:Button runat="server" text="Update With ChangeObjectState" OnClick="UpdateWithChangeObjectState_Click" />
			<asp:Button runat="server" text="Update With SetModifiedProperty" OnClick="UpdateWithSetModifiedProperty_Click" />
			<asp:Button runat="server" text="Update With SetModifiedProperties ExtensionMethod" OnClick="UpdateWithSetModifiedPropertiesExtensionMethod_Click" />
			<asp:Button runat="server" text="Update With stubs" OnClick="UpdateWithStubs_Click" />
			
    </div>
    </form>
</body>
</html>
