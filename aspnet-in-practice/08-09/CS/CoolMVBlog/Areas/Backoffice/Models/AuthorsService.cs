using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoolMvcBlog.Models;
using System.Web.Caching;
using CoolMvcBlog.Utils;

namespace CoolMvcBlog.Areas.Backoffice.Models
{
    public class AuthorsService
    {
        public static List<Author> GetAuthors()
        {
            HttpContext context = HttpContext.Current;
            if (context == null)
                throw new InvalidOperationException("A valid HttpContext is needed");

            var res = context.Cache["authors.all"] as List<Author>;
            if (res == null)
            {
                context.Cache.Insert("authors.all", 
                    res = ObjectContextModule.CurrentContext.AuthorSet.ToList(),
                    null, DateTime.Now.AddHours(1), Cache.NoSlidingExpiration);
            }

            return res;
        }
    }
}