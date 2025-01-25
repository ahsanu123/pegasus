using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;

public partial class Articles : System.Web.UI.Page
{
    protected int Id { get; set; }
    protected string Description { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
       Id = Convert.ToInt32(Page.RouteData.Values["id"]);
       Description = Page.RouteData.Values["description"] as string;

    }
}