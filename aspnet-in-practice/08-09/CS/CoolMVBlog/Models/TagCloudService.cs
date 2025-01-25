using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolMvcBlog.Models
{
    public class TagCloudService
    {
        private BlogModelContainer context;
        public TagCloudService(BlogModelContainer context)
        {
            this.context = context;
        }

        public List<TagCloudItem> GetTagCloudItems()
        {
            var q = (from p in context.PostSet
                    from c in p.Categories
                    group p by new { Id = c.Id, Description = c.Description } into g
                    select new
                    { 
                        CategoryId = g.Key.Id,  
                        Description = g.Key.Description,
                        Size = g.Count()
                    }).ToList();
            
            var max = q.Max(i => i.Size);

            var res = q.Select(i => new TagCloudItem()
            {
                CategoryId = i.CategoryId,
                Description = i.Description,
                Size = this.GetSize(i.Size, max)
            });

            return res.ToList();
        }

        private string GetSize(int p, int max)
        {
            var threshold1 = max * .40;
            var threshold2 = max * .80;

            if (p >= threshold2)
                return "100%";

            if (p >= threshold1)
                return "80%";

            return "60%";
        }
    }
}