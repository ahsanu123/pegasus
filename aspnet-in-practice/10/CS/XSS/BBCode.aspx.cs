using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BBCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void SomeButton_Click(object sender, EventArgs e)
	{
		string text = SomeText.Text;
		text = SecurityUtility.RemoveHtml(text);
		text = SecurityUtility.BBCode(text);
		Results.Text = text;
	}
}
