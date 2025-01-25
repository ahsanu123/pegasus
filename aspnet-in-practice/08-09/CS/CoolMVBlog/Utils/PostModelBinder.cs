using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoolMvcBlog.Utils
{
    public class PostModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext == null)
                throw new ArgumentNullException("controllerContext");
            if (bindingContext == null)
                throw new ArgumentNullException("bindingContext");

            if (bindingContext.Model == null)
            {
                var valueProviderResult = bindingContext.ValueProvider.GetValue("Id");

                if (!string.IsNullOrEmpty(valueProviderResult.AttemptedValue))
                {
                    int id = (int)valueProviderResult.ConvertTo(typeof(int));
                    bindingContext.ModelMetadata.Model = 
                        ObjectContextModule.CurrentContext
                        .PostSet.Include("Categories").Include("Author")
                        .Where(p => p.Id == id).Single();
                }
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}