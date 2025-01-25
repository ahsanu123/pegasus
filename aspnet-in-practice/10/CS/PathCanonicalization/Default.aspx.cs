using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void SubmitButton_Click(object sender, EventArgs e)
	{
		string basePath = "c:\\netput\\mysite";
		try
		{
			Results.Text = "The resulting path is: " + PathExtensions.CanonicalCombine(basePath, PathValue.Text);
		}
		catch (FileNotFoundException)
		{
			Results.Text = "File path not valid!";
		}
	}
}
