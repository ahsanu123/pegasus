using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _DataList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var source = new string[] { "Yogurt", "Beef", "Cheese", "Bread", "Biscuits", "Fish", "Peanuts", "Pasta", "Pork", "Soy", "Other" };
        
        ProductList.DataSource = source;
        ProductList.DataBind();

        ProductList2.DataSource = source;
        ProductList2.DataBind();
    }
}