<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ul>
            <li>
                <a href="<%=Page.GetRouteUrl("ArticleRoute", new RouteValueDictionary { { "Id", 1 }, { "Description", "Test-Url-Routing" } })%>">This is a test url</a>
            </li>
            <li>
                <asp:HyperLink ID="HyperLink1" NavigateUrl="<%$ RouteUrl:RouteName=ArticleRoute,id=5, Description=Test-Url %>" Text="View #5 article" runat="server" />
            </li>
        </ul>
    </div>
    </form>
</body>
</html>
