using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace ASPNET4InPractice.Chapter15
{
    public partial class _Default : System.Web.UI.Page
    {
		protected void StartWork_Click(object sender, EventArgs e)
		{
			// let's start a new instance, and then save in session
			PriceEngine engine = new PriceEngine(FlightNumber.Text);

			Session["engine"] = engine;

			engine.GetFlightPrices();

			// redirect on a waiting page
			Response.Redirect("results.aspx");
		}
    }

}