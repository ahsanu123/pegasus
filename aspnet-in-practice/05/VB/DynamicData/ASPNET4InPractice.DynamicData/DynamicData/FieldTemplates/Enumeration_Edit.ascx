﻿<%@ Control Language="VB" CodeBehind="Enumeration_Edit.ascx.vb" Inherits="ASPNET4InPractice.DynamicData.Enumeration_EditField" %>

<asp:DropDownList ID="DropDownList1" runat="server" CssClass="DDDropDown" />

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" CssClass="DDControl DDValidator" ControlToValidate="DropDownList1" Display="Static" Enabled="false" />
<asp:DynamicValidator runat="server" ID="DynamicValidator1" CssClass="DDControl DDValidator" ControlToValidate="DropDownList1" Display="Static" />

