using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repository;

public partial class Performance : System.Web.UI.Page
{
	protected void AvoidMultipleExcecution_Click(object sender, EventArgs e)
	{
		using (NorthwindEntities ctx = new NorthwindEntities())
		{
			var customers = ctx.Customers.ToList();
			foreach (var c in customers)
			{
			}

			foreach (var c in customers)
			{
			}
		}
	}

	protected void GetObjectByKey_Click(object sender, EventArgs e)
	{
		using (NorthwindEntities ctx = new NorthwindEntities())
		{
			var c = (Customer)ctx.GetObjectByKey(new System.Data.EntityKey("NorthwindEntities.Customers", "CustomerID", "ALFKI"));
			var c2 = (Customer)ctx.GetObjectByKey(new System.Data.EntityKey("NorthwindEntities.Customers", "CustomerID", "ALFKI"));
			ctx.Customers.MergeOption = System.Data.Objects.MergeOption.NoTracking
		}
	}
}