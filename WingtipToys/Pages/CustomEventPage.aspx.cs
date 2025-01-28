using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Builder.Services;
using WingtipToys.CustomControl;
using WingtipToys.Models;

namespace WingtipToys
{
    public partial class CustomEventPage : Page
    {
        protected void Page_Load(object sender, EventArgs e) { }
        protected void GetValueFromPostBack(object sender, EventArgs e)
		{
			Feedback.Text = "Sent from PostBack: " + ((CustomPostBackButton )sender).Value;
		}
    }
}
