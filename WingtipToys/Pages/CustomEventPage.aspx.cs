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
        public Product MyProduct { get; set; } = new Product { Name = "has been search for fucking week", UnitPrice = 10000, Description = "heheheh" };
        protected void Page_Load(object sender, EventArgs e) { }
        protected void GetValueFromPostBack(object sender, EventArgs e)
		{
			Feedback.Text = "Sent from PostBack: " + ((CustomPostBackButton )sender).Value;
		}
    }
}
