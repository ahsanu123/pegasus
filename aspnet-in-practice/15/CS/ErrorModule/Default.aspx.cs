using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{
	protected void MyButton_Click(object sender, EventArgs e)
	{
		int results = 10 / Convert.ToInt32(ErrorBox.Text);
	}
}
