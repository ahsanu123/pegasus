using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using NorthwindModel;

public partial class jQuery : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	[WebMethod]
	public static decimal GetOrdersAmount(string CustomerId)
	{
		using (var ctx = new NorthwindEntities())
		{
			return ctx.Orders.Where(o => o.CustomerID == CustomerId).Sum(o => o.Order_Details.Sum(d => d.UnitPrice * d.Quantity));
		}
	}
}