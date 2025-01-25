using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomControls.Web
{
	public partial class SuperDropDownList : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Countries.DataSource = new string[] { "Italy", "U.S.A.", "U.K.", "Spain" };
				Countries.DataBind();
			}
		}
	}
}