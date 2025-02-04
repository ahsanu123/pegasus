using System;
using WingtipToys.Helper;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Builder.Extension;
using WingtipToys.Builder.Services;
using WingtipToys.Models;
using WingtipToys.Repository;
using Autofac;

namespace WingtipToys
{
    public partial class CreateProductPage : Page
    {
        private IProductRepository _productRepo;

        public CreateProductPage()
        {
           _productRepo= Global._containerProvider.ApplicationContainer.Resolve<IProductRepository>();
        }
        public IEnumerable<String> GetProductForm()
        {
            return typeof(Product).GetForm();
        }
        protected void Page_Load(object sender, EventArgs e) {
            if (IsPostBack)
            {
                var product  =  HelperFunction.GetData<Product>(Request.Form);
                _productRepo.AddProduct(product).GetAwaiter().GetResult();  
            }
        }

        public Product GetProduct([Form]  Product product)
        {
            return product;
        }

        protected void HandleOnSave(object sender, EventArgs e) { }
    }
}
