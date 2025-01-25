using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

public partial class _Default : System.Web.UI.Page 
{
	protected void StartWork_Click(object sender, EventArgs e)
	{
		// let's start a new instance, and then save in session
		PriceEngine engine = new PriceEngine(FlightNumber.Text);

		Session["engine"] = engine;

		// the thread will start the work and immediately execute
		// the next statement
		ThreadPool.QueueUserWorkItem(
		  delegate(object state)
		  {
			  PriceEngine priceEngine = (PriceEngine)state;
			  priceEngine.GetFlightPrices();
		  }, engine);

		// redirect on a waiting page
		Response.Redirect("results.aspx");
	}
}
