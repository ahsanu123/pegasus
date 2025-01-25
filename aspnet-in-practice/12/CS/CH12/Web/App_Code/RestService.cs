using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using NorthwindModel;

[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class RestService
{
	[OperationContract]
	public DateClass GetData()
	{
		return new DateClass { Date = DateTime.Now.ToString(), Utc = DateTime.UtcNow.ToString() };
	}

	[OperationContract]
	public decimal GetOrdersAmount(string CustomerId)
	{
		using (var ctx = new NorthwindEntities())
		{
			return ctx.Orders.Where(o => o.CustomerID == CustomerId).Sum(o => o.Order_Details.Sum(d => d.UnitPrice * d.Quantity));
		}
	}

	[OperationContract]
	[WebGet]
	public string[] GetCustomers(string term)
	{
		using (var ctx = new NorthwindEntities())
		{
			return ctx.Customers.Where(o => o.CompanyName.StartsWith(term)).Select(c => c.CompanyName).ToArray();
		}
	}
}

public class DateClass
{
	public string Date { get; set; }
	public string Utc { get; set; }
}
