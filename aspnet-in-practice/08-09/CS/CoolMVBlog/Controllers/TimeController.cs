using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Mvc.AspNet4;

namespace CoolMvcBlog.Controllers
{
    public class TimeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["ParentActionTime"] = DateTime.Now.ToLongTimeString();
            return View();
        }

        [OutputCache(Duration=30, VaryByParam="none")]
        [ChildActionCache(Duration=30)]
        public ActionResult CurrentServerTime()
        {
            ViewData["time"] = DateTime.Now.ToLongTimeString();

            return this.View();
        }
    }
}
