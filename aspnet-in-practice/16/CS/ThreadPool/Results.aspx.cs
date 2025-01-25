using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Results : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		PriceEngine engine = Session["engine"] as PriceEngine;
		if (engine == null)
			Response.Redirect("./");

		if (engine.Completed)
		{
			ResultsPanel.Visible = true;
			ResultList.DataSource = engine.FlightResults;
			ResultList.DataBind();

			Feedback.Text = string.Format("Elapsed time: {0}",
							engine.EndTime.Subtract(engine.StartTime));
		}
		else
		{
			WaitingPanel.Visible = true;

			// programmatically add a refresh meta tag
			Header.Controls.Add(new HtmlMeta() { HttpEquiv = "refresh", Content = "2" });
		}
    }
}
