using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolMvcBlog.Models
{
    public class HomepageModel : IHasTagCloud
    {
        public List<Post> Posts { get; set; }
        public List<TagCloudItem> TagCloudItems { get; set; }
    }
}