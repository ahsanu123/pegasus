using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoolMvcBlog.Models;
using System.Data.Objects.DataClasses;

namespace CoolMvcBlog.Utils
{
    public class CategoriesModelBinder : IModelBinder
    {   
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext == null)
                throw new ArgumentNullException("controllerContext");
            if (bindingContext == null)
                throw new ArgumentNullException("bindingContext");
            
            EntityCollection<Category> source = bindingContext.Model as EntityCollection<Category>;

            if (source != null)
            {
                IEnumerable<Category> fromRequest = 
                    this.GetPostedCategories(bindingContext);

                if (fromRequest != null)
                { 
                    this.UpdateOriginalCategories(source, fromRequest);
                }
            }
            
            return null;
        }

        private IEnumerable<Category> GetPostedCategories(ModelBindingContext bindingContext)
        {
            var postedValue = bindingContext.ValueProvider.GetValue(
                bindingContext.ModelName + "." + "values");

            if (postedValue == null)
                return null;

            return GetCategoriesFromString(postedValue.AttemptedValue);
        }

        private IEnumerable<Category> GetCategoriesFromString(string stringValues)
        {
            var values = stringValues.Split(';');

            foreach (var item in values)
            {
                int id = int.Parse(item);
                yield return ObjectContextModule.CurrentContext
                    .CategorySet.Where(c => c.Id == id).Single();
            }
        }

        private void UpdateOriginalCategories(
            EntityCollection<Category> source, 
            IEnumerable<Category> fromRequest)
        {
            var toRemove = source.Where(c => !fromRequest.Any(c1 => c1.Id == c.Id)).ToList();
            var toAdd = fromRequest.Where(c => !source.Any(c1 => c1.Id == c.Id)).ToList();

            toRemove.ForEach(c => source.Remove(c));
            toAdd.ForEach(c => source.Add(c));
        }
    }
}