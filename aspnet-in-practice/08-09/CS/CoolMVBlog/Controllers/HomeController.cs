using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoolMvcBlog.Models;
using CoolMvcBlog.Utils;
using System.Web.UI;
using Microsoft.Web.Mvc.AspNet4;
using System.Web.Caching;
using CoolMvcBlog.Utils.Filters;

namespace CoolMvcBlog.Controllers
{
    public class HomeController : Controller
    {
        [LoadTagCloud]
        public ActionResult Index()
        {
            using (var ctx = new BlogModelContainer())
            {
                var lastPosts = ctx.PostSet.OrderByDescending(p => p.DatePublished).Take(3).ToList();
                
                return View(new HomepageModel() { Posts = lastPosts });
            }
        }

        [HttpGet]
        [DependencyOutputCache(Duration = 30, 
            Location=OutputCacheLocation.Server, VaryByParam="None", ParameterName="id")]
        public ActionResult Post(int id, string uniqueName)
        {
            using (var ctx = new BlogModelContainer())
            {
                var post = ctx.PostSet.Include("Comments").Where(p => p.Id == id).Single();
                
                if (post.GetUniqueName() != uniqueName)
                {
                    return new PermanentRedirectResult(
                        this.RedirectToAction("Post", 
                        new { id = id, uniqueName = post.GetUniqueName() }));
                }

                return View(post);
            }
        }

        [HttpPost]
        [RemoveCached(ParameterName = "id")]
        public ActionResult Post(int id, Comment newComment)
        {
            using (var ctx = new BlogModelContainer())
            {
                var post = ctx.PostSet.Include("Comments").Where(p => p.Id == id).Single();

                if (!this.ModelState.IsValid)
                {
                    return this.View(post);
                }

                newComment.Date = DateTime.Now;
                post.Comments.Add(newComment);
                ctx.SaveChanges();

                return RedirectToAction(
                    "Post", 
                    new { id = id, uniqueName = post.GetUniqueName() });
            }
        }
    }
}
