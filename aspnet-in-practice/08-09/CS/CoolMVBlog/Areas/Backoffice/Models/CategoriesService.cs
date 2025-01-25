using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoolMvcBlog.Models;
using System.Web.Caching;
using CoolMvcBlog.Utils;

namespace CoolMvcBlog.Areas.Backoffice.Models
{
    public class CategoriesService
    {
        public static List<Category> GetCategories()
        {
            HttpContext context = HttpContext.Current;
            if (context == null)
                throw new InvalidOperationException("A valid HttpContext is needed");

            var res = context.Cache["categories.all"] as List<Category>;
            if (res == null)
            {
                context.Cache.Insert("categories.all", 
                    res = ObjectContextModule.CurrentContext.CategorySet.ToList(),
                    null, DateTime.Now.AddHours(1), Cache.NoSlidingExpiration);
            }

            return res;
        }
    }
}