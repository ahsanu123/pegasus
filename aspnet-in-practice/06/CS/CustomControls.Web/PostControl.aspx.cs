using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomControls.Composite;

namespace CustomControls.Web
{
	public partial class PostControlPage : System.Web.UI.Page
	{
		protected void Page_Init(object sender, EventArgs e)
		{
			if (!IsPostBack)
				DateView.Value = DateTime.Now;
		}

		protected void GetValueFromPostBack(object sender, EventArgs e)
		{
			Feedback.Text = "Sent from PostBack: " + ((PostControl)sender).Value;
		}


	}
}