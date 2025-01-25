using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Text.RegularExpressions;

namespace CoolMvcBlog.Models
{
    public static class Extensions
    {
        public static string GetUniqueName(this Post post)
        {
            if (post == null)
                throw new ArgumentNullException("post");

            var ctx = HttpContext.Current;
            string cacheKey = "post-staticurl-" + post.Id;

            string res = ctx.Cache[cacheKey] as string;

            if (res == null)
            {
                res = Regex.Replace(post.Title, @"[^A-Za-z0-9\s]", string.Empty);
                res = Regex.Replace(res, @"\s", "-");

                ctx.Cache.Insert(cacheKey, res, null, DateTime.UtcNow.AddMinutes(20), Cache.NoSlidingExpiration);
            }

            return res;
        }

        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }
    }
}