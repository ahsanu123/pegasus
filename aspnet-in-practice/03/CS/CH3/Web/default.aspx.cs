using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repository;

public partial class _default : Page {
	protected override void OnLoad(EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			using (NorthwindEntities ctx = new NorthwindEntities())
			{
				ctx.ContextOptions.ProxyCreationEnabled = false;
				ctx.Customers.ToTraceString();
				var c = ctx.Customers.First();
				ViewState["c"] = c;
				fax.Text = c.Fax;
			}
		}
		base.OnLoad(e);
	}

	protected void btn_click(object sender, EventArgs e)
	{
		using (NorthwindEntities ctx = new NorthwindEntities())
		{
			var c = (Customer)ViewState["c"];
			ctx.Customers.Attach(c);
			c.Fax = fax.Text;
			ctx.SaveChanges();
		}
	}
}