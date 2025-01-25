<%@ Page Language="vb" AutoEventWireup="true" CodeFile="admin.aspx.vb" Inherits="admin" ValidateRequest="false" %>

<%@ Register assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" namespace="System.Web.UI.WebControls" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin VirtualFileSystem</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    	<asp:EntityDataSource ID="VirtualFileSystemDataSource" runat="server" 
			ConnectionString="name=VirtualFileSystemEntities" 
			DefaultContainerName="VirtualFileSystemEntities" EnableDelete="True" 
			EnableInsert="True" EnableUpdate="True" EntitySetName="VirtualFiles">
		</asp:EntityDataSource>
		<asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" 
			DataSourceID="VirtualFileSystemDataSource" InsertItemPosition="LastItem">
			<ItemTemplate>
				<tr style="background-color:#DCDCDC;color: #000000;">
					<td>
						<asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
							Text="Delete" />
						<asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
					</td>
					<td>
						<asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
					</td>
					<td>
						<asp:Label ID="VirtualPathLabel" runat="server" 
							Text='<%# Eval("VirtualPath") %>' />
					</td>
					<td>
						<%# Server.HtmlEncode(Eval("Contents").ToString()).Replace("\r\n", "<br />") %>
					</td>
					<td>
						<asp:Label ID="LastUpdatedLabel" runat="server" 
							Text='<%# Eval("LastUpdated") %>' />
					</td>
				</tr>
			</ItemTemplate>
			<AlternatingItemTemplate>
				<tr style="background-color:#FFF8DC;">
					<td>
						<asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
							Text="Delete" />
						<asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
					</td>
					<td>
						<asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
					</td>
					<td>
						<asp:Label ID="VirtualPathLabel" runat="server" 
							Text='<%# Eval("VirtualPath") %>' />
					</td>
					<td>
						<asp:Label ID="ContentsLabel" runat="server" Text='<%# Eval("Contents") %>' />
					</td>
					<td>
						<asp:Label ID="LastUpdatedLabel" runat="server" 
							Text='<%# Eval("LastUpdated") %>' />
					</td>
				</tr>
			</AlternatingItemTemplate>
			<EmptyDataTemplate>
				<table runat="server" 
					style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
					<tr>
						<td>
							No data was returned.</td>
					</tr>
				</table>
			</EmptyDataTemplate>
			<InsertItemTemplate>
				<tr style="">
					<td>
						<asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
							Text="Insert" />
						<asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
							Text="Clear" />
					</td>
					<td>
						<asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
					</td>
					<td>
						<asp:TextBox ID="VirtualPathTextBox" runat="server" 
							Text='<%# Bind("VirtualPath") %>' />
					</td>
					<td>
						<asp:TextBox ID="ContentsTextBox" runat="server" TextMode="MultiLine"
							Text='<%# Bind("Contents") %>' />
					</td>
					<td>
						<asp:TextBox ID="LastUpdatedTextBox" runat="server" 
							Text='<%# Bind("LastUpdated") %>' />
					</td>
				</tr>
			</InsertItemTemplate>
			<LayoutTemplate>
				<table runat="server" width="100%">
					<tr runat="server">
						<td runat="server">
							<table ID="itemPlaceholderContainer" runat="server" border="1" width="100%"
								style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
								<tr runat="server" style="background-color:#DCDCDC;color: #000000;">
									<th runat="server">
									</th>
									<th runat="server">
										ID</th>
									<th runat="server">
										VirtualPath</th>
									<th runat="server">
										Contents</th>
									<th runat="server">
										LastUpdated</th>
								</tr>
								<tr ID="itemPlaceholder" runat="server">
								</tr>
							</table>
						</td>
					</tr>
					<tr runat="server">
						<td runat="server" 
							style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
						</td>
					</tr>
				</table>
			</LayoutTemplate>
			<EditItemTemplate>
				<tr style="background-color:#008A8C;color: #FFFFFF;">
					<td>
						<asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
							Text="Update" />
						<asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
							Text="Cancel" />
					</td>
					<td>
						<asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' />
					</td>
					<td>
						<asp:TextBox ID="VirtualPathTextBox" runat="server" 
							Text='<%# Bind("VirtualPath") %>' />
					</td>
					<td>
						<asp:TextBox ID="ContentsTextBox" runat="server" TextMode="MultiLine"
							Text='<%# Bind("Contents") %>' />
					</td>
					<td>
						<asp:TextBox ID="LastUpdatedTextBox" runat="server" ReadOnly="true"
							Text='<%# Bind("LastUpdated") %>' />
					</td>
				</tr>
			</EditItemTemplate>
			<SelectedItemTemplate>
				<tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
					<td>
						<asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
							Text="Delete" />
						<asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
					</td>
					<td>
						<asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
					</td>
					<td>
						<asp:Label ID="VirtualPathLabel" runat="server" 
							Text='<%# Eval("VirtualPath") %>' />
					</td>
					<td>
						<asp:Label ID="ContentsLabel" runat="server" Text='<%# Eval("Contents") %>' />
					</td>
					<td>
						<asp:Label ID="LastUpdatedLabel" runat="server" 
							Text='<%# Eval("LastUpdated") %>' />
					</td>
				</tr>
			</SelectedItemTemplate>
		</asp:ListView>
    
    </div>
    </form>
</body>
</html>
