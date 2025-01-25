using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectModel;
using Data;

namespace Business {
	public class OrderManager {
		public List<OrderDTO> GetOrders(int pageIndex, int pageCount, string shippingAddress, string customerName, decimal totalAmount, int productId, string sortField) {
			return new OrderData().GetOrders(pageIndex, pageCount, shippingAddress, customerName, totalAmount, productId, sortField);
		}
		public Order ReadOrder(int orderId) {
			return new OrderData().ReadOrder(orderId);
		}
	}
}
