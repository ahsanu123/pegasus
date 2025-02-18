using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web.UI;
using System.Web.UI.WebControls;
using Autofac;
using Newtonsoft.Json;
using WingtipToys.ApplicationState;
using WingtipToys.CustomControl;
using WingtipToys.Helper;
using WingtipToys.Models;
using WingtipToys.Repository;
using WingtipToys.Routes;

namespace WingtipToys
{
    public class ProductPageState : IPageStateBase
    {
        public string Id { get; set; } = nameof(ProductPageState);
        public IEnumerable<Product> Products { get; set; }
        public int? EditModeIndex { get; set; } = null;
    }

    public class IsEditModeProduct
    {
        public int Id { get; set; }
        public bool IsEditMode { get; set; }
    }

    public partial class ProductPage : Page
    {
        private IProductRepository _productRepo { get; set; }
        public ProductPageState State { get; set; } = new ProductPageState();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageState.Subscribe(nameof(ProductPageState), this.OnPageStateUpdated);

                State.Products = GetProductData();
                PageState.SetState(State);
                BindMainRepeater();
            }
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            PageState.Unsubscribe(nameof(ProductPageState));
        }

        public void OnPageStateUpdated(IPageStateBase stateBase)
        {
            DebugLabel.Text = JsonConvert.SerializeObject(
                PageState.GetState<ProductPageState>(nameof(ProductPageState))
            );

            State = (ProductPageState)stateBase;

            BindMainRepeater();
        }

        private void BindMainRepeater()
        {
            MainRepeater.DataSource = State.Products;
            MainRepeater.DataBind();
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
                var product = e.GetRepeaterDataItem<Product>();
                var productCard = e.FindControlAs<ProductCard>("ProductCard");

                if (productCard != null)
                {
                    productCard.Product = product;

                    var pageState = PageState.GetState<ProductPageState>(nameof(ProductPageState));
                    productCard.IsEditMode = product.Id % 2 == 0;
                }
            }
        }

        private void ProductCardEventHandler(object sender, ProductCardEventArgs e)
        {
            //var productCard = (TwoWayProductCard)sender;

            //switch (e.EventType)
            //{
            //    case ProductCardEventType.Save:
            //        break;
            //    case ProductCardEventType.Cancel:
            //        break;
            //    case ProductCardEventType.Edit:
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
