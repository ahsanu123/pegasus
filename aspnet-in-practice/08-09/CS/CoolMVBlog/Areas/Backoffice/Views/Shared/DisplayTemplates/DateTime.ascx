<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.DateTime>" %>
<%: this.Model.ToLongDateString() %>