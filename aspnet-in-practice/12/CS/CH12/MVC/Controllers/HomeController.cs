using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Data;

namespace MVC.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			using (var ctx = new NorthwindEntities ()){
				ViewData["Regions"] = ctx.Region.ToList().Select(r => new SelectListItem { Value = r.RegionID.ToString(), Text = r.RegionDescription });
			}
			return View();
		}

		public ActionResult GetTerritories(int RegionId)
		{
			return View();
		}

		public ActionResult GetOrdersAmount(string CustomerId)
		{
			using (var ctx = new NorthwindEntities())
			{
				return Content(ctx.Orders.Where(o => o.CustomerID == CustomerId).Sum(o => o.Order_Details.Sum(d => d.UnitPrice * d.Quantity)).ToString());
			}
		}
	}
}
