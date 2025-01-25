using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cache;

public partial class CachePage : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		ProviderName.Text = CacheFactory.Instance.Name;
		CustomerList.DataSource = GetCustomers();
		CustomerList.DataBind();
	}

	private static object lockObject = new object();

	public List<Customer> GetCustomers()
	{
		string cacheKey = "customers";
		List<Customer> customers = CacheFactory.Instance[cacheKey] as List<Customer>;

		if (customers == null)
		{
			lock (lockObject)
			{
				customers = CacheFactory.Instance[cacheKey] as List<Customer>;
				if (customers == null)
				{
					customers = new List<Customer>{
						new Customer{FirstName="Daniele", LastName="Bochicchio"},
						new Customer{FirstName="Marco", LastName="De Sanctis"},
						new Customer{FirstName="Stefano", LastName="Mostarda"}
					};

					CacheFactory.Instance[cacheKey] = customers;
				}
			}
		}
		return customers;
	}

}