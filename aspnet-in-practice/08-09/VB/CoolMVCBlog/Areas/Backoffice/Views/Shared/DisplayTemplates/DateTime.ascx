<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of System.DateTime)" %>
<%: Me.Model.ToLongDateString() %>