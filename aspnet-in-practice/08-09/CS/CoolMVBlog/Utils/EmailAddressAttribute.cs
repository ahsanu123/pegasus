using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CoolMvcBlog.Utils
{
    public class EmailAddressAttribute : RegularExpressionAttribute
    {
        internal const string EmailRegex = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}\b";

        public EmailAddressAttribute(): base(EmailRegex)
        {
            this.ErrorMessage = "Please provide a valid email address";
        }
    }
}