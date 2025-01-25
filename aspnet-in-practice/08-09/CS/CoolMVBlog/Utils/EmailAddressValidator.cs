using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoolMvcBlog.Utils
{
    public class EmailAddressValidator : DataAnnotationsModelValidator<EmailAddressAttribute>
    {
        public EmailAddressValidator(
            ModelMetadata metadata, ControllerContext context, EmailAddressAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRegexRule(this.ErrorMessage, EmailAddressAttribute.EmailRegex);

            yield return rule;
        }
    }
}