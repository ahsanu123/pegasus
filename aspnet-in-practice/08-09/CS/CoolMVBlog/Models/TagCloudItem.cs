using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolMvcBlog.Models
{
    public class TagCloudItem
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
    }
}
