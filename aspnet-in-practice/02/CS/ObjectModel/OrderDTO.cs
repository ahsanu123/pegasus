using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectModel {
	public class OrderDTO {
		public string ShipAddress { get; set; }
		public string ShipCity { get; set; }
		public string ShipCountry { get; set; }
		public string ShipPostalCode { get; set; }
		public string CustomerName { get; set; }
		public decimal Total { get; set; }
	}
}
