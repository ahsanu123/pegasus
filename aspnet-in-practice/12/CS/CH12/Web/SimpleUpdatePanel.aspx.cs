using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NorthwindModel;
using System.Net;

public partial class SimpleUpdatePanel : System.Web.UI.Page
{
	protected override void OnLoad(EventArgs e)
	{
		try
		{
			IPHostEntry MyHost = Dns.Resolve("www.microgame.it");

			foreach (IPAddress MyIP in MyHost.AddressList)
			{
				Response.Write(MyIP.Address);
			}
		}
		catch
		{
		
		}


		if (!Page.IsPostBack)
		{
			using (var ctx = new NorthwindEntities())
			{
				Regions.DataSource = ctx.Region;
				Regions.DataBind();
			}
		}
	}
	protected void Regions_Changed(object sender, EventArgs e)
	{
		using (var ctx = new NorthwindEntities())
		{
			int id = Convert.ToInt32(Regions.SelectedValue);
			Territories.DataSource = ctx.Territories.Where(t => t.RegionID == id);
			Territories.DataBind();
		}
	}
}