using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoolMvcBlog.Utils
{
    public class PermanentRedirectResult : ActionResult
    {
        private ActionResult innerResult;

        public PermanentRedirectResult(RedirectToRouteResult result)
        {
            if (result == null)
                throw new ArgumentNullException("result");

            this.innerResult = result;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            this.innerResult.ExecuteResult(context);

            var response = context.HttpContext.Response;
            var url = response.RedirectLocation;

            response.RedirectPermanent(url, false);
        }
    }
}