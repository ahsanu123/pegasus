using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolMvcBlog.Models
{
    internal interface IHasTagCloud
    {
        List<TagCloudItem> TagCloudItems { get; set; }
    }
}
