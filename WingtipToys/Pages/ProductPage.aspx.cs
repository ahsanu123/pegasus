using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web.UI;
using System.Web.UI.WebControls;
using Autofac;
using WingtipToys.CustomControl;
using WingtipToys.Helper;
using WingtipToys.Models;
using WingtipToys.Repository;
using WingtipToys.Routes;

namespace WingtipToys
{
    public class IsEditModeProduct
    {
        public int Id { get; set; }
        public bool IsEditMode { get; set; }
    }

    public partial class ProductPage : Page
    {
        private const string _listProductSession = "ListProduct";
        private const string _listProductIsEditMode = "ListProductIsEditMode";
        private IProductRepository _productRepo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var products = GetProductData();
                Session[_listProductSession] = products;
                Session[_listProductIsEditMode] = products.Select(item => new IsEditModeProduct
                {
                    Id = item.Id,
                    IsEditMode = (item.Id % 2 == 0) ? true : false,
                });
                BindProductRepeaterData();
            }
        }

        private void BindProductRepeaterData()
        {
            ProductRepeater.DataSource = Session[_listProductSession];
            ProductRepeater.DataBind();
        }

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

        protected void ProductRepeaterOnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsRepeaterItem())
            {
                var data = e.GetRepeaterDataItem<Product>();
                var control = e.FindControlAs<TwoWayProductCard>("twoWayProductCard");
                var isListProductEditMode =
                    (IEnumerable<IsEditModeProduct>)Session[_listProductIsEditMode];

                if (control != null)
                {
                    control.Product = data;
                    control.IsEditMode = isListProductEditMode.FirstOrDefault(item => item.Id == data.Id).IsEditMode;
                    control.ProductCardEvent += ProductCardEventHandler;
                }
            }
        }

        private void ProductCardEventHandler(object sender, ProductCardEventArgs e)
        {
            var productCard = (TwoWayProductCard)sender;

            switch (e.EventType)
            {
                case ProductCardEventType.Save:
                    break;
                case ProductCardEventType.Cancel:
                    break;
                case ProductCardEventType.Edit:
                    break;
                default:
                    break;
            }
        }
    }
}
