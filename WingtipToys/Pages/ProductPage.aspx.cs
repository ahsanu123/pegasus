using System;
using System.Collections.Generic;
using System.Web.UI;
using Autofac;
using WingtipToys.Models;
using WingtipToys.Repository;
using WingtipToys.Routes;

namespace WingtipToys
{
    public partial class ProductPage : Page
    {
        private IProductRepository _productRepo { get; set; }

        protected void Page_Load(object sender, EventArgs e) { }

        public ProductPage()
        {
            _productRepo =
                Global._containerProvider.ApplicationContainer.Resolve<IProductRepository>();
        }

        public IEnumerable<Product> GetProductData()
        {
            return _productRepo.GetProducts().GetAwaiter().GetResult();
        }

        protected void HandleOnAddProduct(object sender, EventArgs e)
        {
            Response.Redirect(PhysicalPath.CreateProductPage);
        }
    }
}
