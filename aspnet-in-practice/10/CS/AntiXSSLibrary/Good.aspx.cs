using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class Good : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void SomeButton_Click(object sender, EventArgs e)
	{
		Results.Text = AntiXss.HtmlEncode(SomeText.Text);
		ClientScript.RegisterStartupScript(this.GetType(), "alert",
					string.Format("alert({0});", AntiXss.JavaScriptEncode(SomeText.Text)), true);
	}
}
