using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web.UI;
using System.Web.UI.WebControls;
using Autofac;
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
        public ProductPageState State {  get; set; } = new ProductPageState();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageState.StateChange += OnPageStateUpdated;

                State.Products = GetProductData();
                PageState.SetState(State);
                BindMainRepeater();
            }
        }

        protected void OnPageStateUpdated(string key, IPageStateBase stateBase)
        {
            if(key == nameof(ProductPageState))
            {
                Updatepanel.Update();
            }
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
            //if (e.IsRepeaterItem())
            //{
            //    var data = e.GetRepeaterDataItem<Product>();
            //    var control = e.FindControlAs<TwoWayProductCard>("twoWayProductCard");
            //    var isListProductEditMode =
            //        (IEnumerable<IsEditModeProduct>)Session[_listProductIsEditMode];

            //    if (control != null)
            //    {
            //        control.Product = data;
            //        control.IsEditMode = isListProductEditMode
            //            .FirstOrDefault(item => item.Id == data.Id)
            //            .IsEditMode;
            //        control.ProductCardEvent += ProductCardEventHandler;
            //    }
            //}
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
