using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repository;
using System.Data;

public partial class Updates : System.Web.UI.Page
{
	protected void UpdateWithChangeObjectState_Click(object sender, EventArgs e)
	{
		using (NorthwindEntities ctx = new NorthwindEntities())
		{
			var customer = new Customer()
			{
				CustomerID = "15455",
				Address = "Address",
				City = "City",
				CompanyName = "CompanyName",
				ContactName = "ContactName",
				ContactTitle = "ContactTitle",
				Country = "Country",
				Fax = "11111",
				Phone = "222222",
				PostalCode = "00000",
				Region = "Region"
			};
			ctx.Customers.Attach(customer);
			ctx.ObjectStateManager.ChangeObjectState(customer, EntityState.Modified);
			ctx.SaveChanges();
		}
	}
	protected void UpdateWithSetModifiedProperty_Click(object sender, EventArgs e)
	{
		using (NorthwindEntities ctx = new NorthwindEntities())
		{
			var customer = new Customer()
			{
				CustomerID = "15455",
				Address = "Address",
				Country = "Country",
				Fax = "11111",
				Phone = "222222",
				PostalCode = "00000",
				Region = "Region"
			};
			ctx.Customers.Attach(customer);
			var entry = ctx.ObjectStateManager.GetObjectStateEntry(customer);
			entry.SetModifiedProperty("Address");
			entry.SetModifiedProperty("Country");
			entry.SetModifiedProperty("Fax");
			entry.SetModifiedProperty("Phone");
			entry.SetModifiedProperty("PostalCode");
			entry.SetModifiedProperty("Region");
			ctx.SaveChanges();
		}
	}
	protected void UpdateWithSetModifiedPropertiesExtensionMethod_Click(object sender, EventArgs e)
	{
		using (NorthwindEntities ctx = new NorthwindEntities())
		{
			var customer = new Customer()
			{
				CustomerID = "15455",
				Address = "Address",
				Country = "Country",
				Fax = "11111",
				Phone = "222222",
				PostalCode = "00000",
				Region = "Region"
			};
			ctx.Customers.Attach(customer);
			var entry = ctx.ObjectStateManager.GetObjectStateEntry(customer);
			entry.SetModifiedProperties("Address", "Country", "Fax", "Phone", "PostalCode", "Region");
			ctx.SaveChanges();
		}
	}

	protected void UpdateWithStubs_Click(object sender, EventArgs e)
	{
		using (NorthwindEntities ctx = new NorthwindEntities())
		{
			var customer = new Customer()
			{
				CustomerID = "15455",
			};
			ctx.Customers.Attach(customer);
			customer.Address = "Address";
			customer.Country = "Country";
			customer.Fax = "11111";
			customer.Phone = "222222";
			customer.PostalCode = "00000";
			customer.Region = "Region";
			try
			{
				ctx.SaveChanges();
			}
			catch (OptimisticConcurrencyException)
			{
			}
		}
	}
}