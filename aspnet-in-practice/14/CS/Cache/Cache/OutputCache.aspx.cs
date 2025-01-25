using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cache
{
	public partial class OutputCache : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			CustomerList.DataSource = GetCustomers();
			CustomerList.DataBind();
		}

		public List<Customer> GetCustomers()
		{
			return new List<Customer>{
						new Customer{FirstName="Daniele", LastName="Bochicchio"},
						new Customer{FirstName="Marco", LastName="De Sanctis"},
						new Customer{FirstName="Stefano", LastName="Mostarda"}
					};
		}
	}
}