using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects.DataClasses;

namespace CoolMvcBlog.Models
{
    public class PostMetadata
    {
        [UIHint("Categories")]
        public EntityCollection<Category> Categories { get; set; }
        
        [UIHint("Author")]
        public int AuthorId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
    }

    [MetadataType(typeof(PostMetadata))]
    public partial class Post
    { 

    }
}