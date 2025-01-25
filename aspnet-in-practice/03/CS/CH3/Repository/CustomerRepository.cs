using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Repository {
	public class CustomerRepository {
		public void CreateContext() {
			HttpContext.Current.Items["__EFCONTEXT"] = new NorthwindEntities();
		}

		public void DestroyContext() {
			((NorthwindEntities)HttpContext.Current.Items["__EFCONTEXT"]).Dispose();
		}
	}
}