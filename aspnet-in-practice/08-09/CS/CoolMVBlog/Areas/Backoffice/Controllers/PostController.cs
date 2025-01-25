using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoolMvcBlog.Models;
using CoolMvcBlog.Areas.Backoffice.Models;
using System.Data;
using System.Data.Objects;
using CoolMvcBlog.Utils;

namespace CoolMvcBlog.Areas.Backoffice.Controllers
{
    public class PostController : Controller
    {
        public ActionResult Index()
        {
            return this.View(ObjectContextModule.CurrentContext
                    .PostSet
                    .Include("Author")
                    .OrderByDescending(p => p.DatePublished)
                    .ToList());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            this.ViewData["Authors"] = AuthorsService.GetAuthors();
            this.ViewData["Categories"] = CategoriesService.GetCategories();
            return View(ObjectContextModule.CurrentContext
                .PostSet
                .Include("Author")
                .Include("Categories")
                .Where(p => p.Id == id)
                .Single());
        }

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (this.ModelState.IsValid)
            {
                ObjectContextModule.CurrentContext.SaveChanges();
                return this.RedirectToAction("Index");
            }

            this.ViewData["Authors"] = AuthorsService.GetAuthors();
            this.ViewData["Categories"] = CategoriesService.GetCategories();

            return this.View(post);
        }

        //[HttpPost]
        //public ActionResult Edit(Post post)
        //{
        //    if (this.ModelState.IsValid)
        //    {
        //        using (BlogModelContainer ctx = new BlogModelContainer())
        //        {
        //            var original = ctx.PostSet
        //                .Where(p => p.Id == post.Id)
        //                .Single();

        //            if (this.TryUpdateModel(original))
        //            {
        //                ctx.SaveChanges();
        //                return this.RedirectToAction("Index");
        //            }
        //        }
        //    }

        //    this.ViewData["Authors"] = AuthorsService.GetAuthors();
        //    this.ViewData["Categories"] = CategoriesService.GetCategories();

        //    return this.View(post);
        //}
    }
}
