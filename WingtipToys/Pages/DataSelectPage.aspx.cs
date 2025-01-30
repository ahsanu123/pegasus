using System;
using System.Collections.Generic;
using System.Web.UI;
using Autofac;
using WingtipToys.Models;
using WingtipToys.Repository;

namespace WingtipToys
{
    public partial class DataSelectPage : Page
    {
        private IProductRepository _productRepo { get; set; }

        protected void Page_Load(object sender, EventArgs e) { }

        protected Product MyProduct = new Product { Name = "Apple", Description = "An Red Apple", UnitPrice = 2 };
        public DataSelectPage()
        {
            _productRepo =
                Global._containerProvider.ApplicationContainer.Resolve<IProductRepository>();
        }

        public IEnumerable<Product> GetProductData()
        {
            return _productRepo.GetProducts().GetAwaiter().GetResult();
        }
    }
}
