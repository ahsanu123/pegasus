﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;

public partial class Redirect : System.Web.UI.Page
{
    protected void TestRedirect(object sender, EventArgs e)
    {
        Response.RedirectToRoute("ArticleRoute", new RouteValueDictionary { { "Id", 5 }, { "Description", "Test-URL" } });
    }
}