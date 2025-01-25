using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectModel;
using Data;

namespace Business {
	public class CustomerManager {
		public void Create(Customer customer) {
			new CustomerData().Create(customer);
		}
		public void Update(Customer customer) {
			new CustomerData().Update(customer);
		}
		public void Delete(Customer customer) {
			new CustomerData().Delete(customer);
		}
	}
}
