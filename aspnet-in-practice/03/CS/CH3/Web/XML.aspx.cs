using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Repository;

public partial class XML : System.Web.UI.Page
{
	protected void btnCreate_Click(object sender, EventArgs e)
	{
		XDocument doc = new XDocument(
			new XDeclaration("1.0", "utf-8", "true"),
			new XComment("comment"),
			new XElement("Customers",
				new XElement("Customer",
					new XAttribute("Id", "ALFKI"),
					new XElement("Name", "NAME")
				)
			)
		);

		txt.Text = doc.ToString();
	}

	protected void btnFilter_Click(object sender, EventArgs e)
	{
		var doc = XDocument.Parse(txt.Text);
		var france = doc.Root.Elements("Customer").Where(c => c.Element("Country").Value == "France")
			.Select(c => new { Name = c.Element("Name").Value, Country = c.Element("Country").Value });
		grd.DataSource = france;
		grd.DataBind();
	}

	protected void btnSort_Click(object sender, EventArgs e)
	{
		var doc = XDocument.Parse(txt.Text);
		var x = doc.Root.Elements("Customer")
			.OrderBy(c => c.Element("Name").Value)
			.Select(c => new { Name = c.Element("Name").Value, Country = c.Element("Country").Value });
		grd.DataSource = x;
		grd.DataBind();
	}

	protected void btnCreateFromDB_Click(object sender, EventArgs e)
	{
		using (NorthwindEntities ctx = new NorthwindEntities())
		{
			var customers = ctx.Customers.Take(10).ToList();
			var doc =
				new XDocument(
					new XElement("Customers",
						from c in customers
						select new XElement("Customer",
							new XElement("Name", c.CompanyName),
							new XElement("Address", c.Address),
							new XElement("PostalCode", c.PostalCode),
							new XElement("City", c.City),
							new XElement("Country", c.Country)
						)
					)
				);
			txt.Text = doc.ToString();
		}
	}
}