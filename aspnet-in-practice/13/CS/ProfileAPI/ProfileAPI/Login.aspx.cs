﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ProfileAPI
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Button1_Click(object sender, EventArgs e)
		{
			FormsAuthentication.RedirectFromLoginPage("username", true);
		}
	}
}