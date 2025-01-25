using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using ObjectModel;

public partial class _Default : System.Web.UI.Page {
	protected void Page_Load(object sender, EventArgs e) {
		grd.DataSource = new Business.OrderManager().GetOrders(1, 10, "Seattle", "Alfreds Futterkiste", 1000, 2, "shipcity");
		grd.DataBind();
	}

	protected void btnClick(object sender, EventArgs e) {
		var c = new Customer(){
			Address = "address",
			City = "City",
			CompanyName = "CompanyName",
			ContactName = "ContactName", 
			ContactTitle = "ContactTitle",
			Country = "Country",
			CustomerID = "15455",
			Fax = "222222",
			Phone = "2333333",
			PostalCode = "123445",
 			Region = "Region"
		};
		new CustomerManager().Create(c);
	}
}