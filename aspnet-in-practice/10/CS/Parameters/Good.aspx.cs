using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Good : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		int id;
		if (int.TryParse(Request.QueryString["ID"], out id))
		{
			// parameter is ok and the variable initialized

		}

	}
}
