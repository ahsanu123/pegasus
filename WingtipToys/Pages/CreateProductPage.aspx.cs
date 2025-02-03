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

namespace WingtipToys
{
    public partial class CreateProductPage : Page
    {
        public IEnumerable<String> GetProductForm()
        {
            return typeof(Product).GetProperties().Select(item => item.Name).ToList();
        }
        protected void Page_Load(object sender, EventArgs e) {
            if (IsPostBack)
            {
                //debugBox.Text = HelperFunction.GetData<Product>(Request.Form).Name;
                debugBox.Text = HelperFunction.GetData<Product>(Request.Form).Name;
            }
        }

        public Product GetProduct([Form]  Product product)
        {
            return product;
        }

        protected void HandleOnSave(object sender, EventArgs e) { }
    }
}
