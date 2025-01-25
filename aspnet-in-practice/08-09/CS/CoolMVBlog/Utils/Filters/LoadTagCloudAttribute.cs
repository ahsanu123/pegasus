using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoolMvcBlog.Models;

namespace CoolMvcBlog.Utils.Filters
{
    public class LoadTagCloudAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            
            var view = filterContext.Result as ViewResult;
            if (view == null)
                return;

            var model = view.ViewData.Model as IHasTagCloud;
            if (model == null)
                return;

            using (var ctx = new BlogModelContainer())
            {
                var service = new TagCloudService(ctx);

                model.TagCloudItems = service.GetTagCloudItems();
            }
        }
    }
}