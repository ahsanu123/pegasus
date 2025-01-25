using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectModel;

namespace Data {
	public class CustomerData {
		public void Create(Customer customer) {
			using (var ctx = new NorthwindEntities()) {
				ctx.Customers.AddObject(customer);
				ctx.SaveChanges();
			}
		}
		public void Update(Customer customer) {
			using (var ctx = new NorthwindEntities()) {
				ctx.Customers.Attach(customer);
				ctx.ObjectStateManager.GetObjectStateEntry(customer).ChangeState(System.Data.EntityState.Modified);
				ctx.SaveChanges();
			}
		}
		public void Delete(Customer customer) {
			using (var ctx = new NorthwindEntities()) {
				ctx.Customers.Attach(customer);
				ctx.Customers.DeleteObject(customer);
				ctx.SaveChanges();
			}
		}
	}
}
