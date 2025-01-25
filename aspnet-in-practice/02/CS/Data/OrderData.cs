using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectModel;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.SqlClient;

namespace Data {
	public class OrderData {
		public List<OrderDTO> GetOrders(int pageIndex, int pageCount, string shippingAddress, string customerName, decimal totalAmount, int productId, string sortField) {
			using (var ctx = new NorthwindEntities()) {
				IQueryable<Order> result = ctx.Orders;
				if (!String.IsNullOrEmpty(shippingAddress))
					result = result.Where(o => o.Order_Details.Any(d => d.ProductID == productId));
				if (!String.IsNullOrEmpty(customerName))
					result = result.Where(o => o.Customer.CompanyName == customerName);
				if (totalAmount > 0)
					result = result.Where(o => o.Order_Details.Sum(d => (d.UnitPrice * d.Quantity)) > totalAmount);
				if (productId > 0)
					result = result.Where(o => o.Order_Details.Any(d => d.ProductID == productId));

				if (sortField == "shipcity")
					result = result.OrderBy(o => o.ShipCity);
				else if (sortField == "shipaddress")
					result = result.OrderBy(o => o.ShipAddress);
				else
					result = result.OrderBy(o => o.ShipCountry);

				IQueryable<OrderDTO> finalResult = result.Select(o => new OrderDTO { CustomerName = o.Customer.CompanyName, ShipAddress = o.ShipAddress, ShipCity = o.ShipCity, ShipCountry = o.ShipCountry, ShipPostalCode = o.ShipPostalCode, Total = o.Order_Details.Sum(d => (d.UnitPrice * d.Quantity)) });
				return finalResult.ToList();

				
				//return ctx.Orders.Where(o => o.Order_Details.Any(d => d.ProductID == productId)).ToList();
				//return ctx.Orders.Where(o => o.Order_Details.Sum(d => (d.UnitPrice * d.Quantity)) > 1000).ToList();
				//return ctx.Orders.Where(o => o.Customer.CompanyName == customerName).ToList();
				//return ctx.Orders.Where(o => o.ShipCity == shippingAddress).ToList();
			}
		}
		public Order ReadOrder(int orderId) {
			using (var ctx = new NorthwindEntities()) {
				return ctx.Orders.First(o => o.OrderID == orderId);
			}
		}
	}
}