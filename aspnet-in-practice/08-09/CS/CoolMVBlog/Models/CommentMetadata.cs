using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CoolMvcBlog.Utils;

namespace CoolMvcBlog.Models
{
    public class CommentMetadata
    {
        [Required(ErrorMessage="Author is mandatory")]
        public string Author { get; set; }

        [Required(ErrorMessage="Email is mandatory")]
        [EmailAddress]
        [RegularExpression(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}\b", ErrorMessage="Please provide a valid Email address")]
        public string Email { get; set; }

        [Required(ErrorMessage="You should post some text")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
    }

    [MetadataType(typeof(CommentMetadata))]
    public partial class Comment
    { }
}