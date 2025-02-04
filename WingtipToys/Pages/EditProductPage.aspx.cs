using Autofac;
using Elmah.ContentSyndication;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Builder.Services;
using WingtipToys.Helper;
using WingtipToys.Models;
using WingtipToys.Repository;

namespace WingtipToys
{
    public partial class EditProductPage : Page
    {

        private int  _id;
        private IProductRepository _productRepo;
        public EditProductPage()
        {
            _productRepo = Global._containerProvider.ApplicationContainer.Resolve<IProductRepository>();
        }
        public IEnumerable<String> GetProductForm()
        { 
            var product = GetProduct();
            var inputModels = new List<InputModel>();

            //inputModels.Add(new InputModel()
            //{
            //    Name = nameof(Product.Name),
            //    Value = product.Name ?? "empty",
            //});

            //inputModels.Add(new InputModel()
            //{
            //    Name= nameof(Product.Type),
            //    Type = "text",
            //    Value= product.Type
            //});
            //inputModels.Add(new InputModel()
            //{
            //    Name= nameof(Product.ImageUrl),
            //    Type = "text",
            //    Value= product.ImageUrl
            //});
            //inputModels.Add(new InputModel()
            //{
            //    Name= nameof(Product.UnitPrice),
            //    Type = "text",
            //    Value= product.UnitPrice.ToString()
            //});

            return typeof(Product).GetForm();
          //  return inputModels;
        }
        protected void Page_Load(object sender, EventArgs e) {
            formview.ChangeMode(FormViewMode.Edit);
        }

        protected void HandleOnSave(object sender, EventArgs e) { }

        public Product GetProduct()
        {
            return  _productRepo.GetProductById(_id).GetAwaiter().GetResult();  
        }

        public string GetId([QueryString] string id)
        {
            var intId = 0;
            int.TryParse(id, out intId);
            _id = intId;

            return id ?? "nothing";
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public object formview_GetItem(int id)
        {
            return null;
        }
    }
}
