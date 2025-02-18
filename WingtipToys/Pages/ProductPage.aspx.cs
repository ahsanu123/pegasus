using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
        public int? EditModeId { get; set; } = null;
    }

    public class IsEditModeProduct
    {
        public int Id { get; set; }
        public bool IsEditMode { get; set; }
    }

    public partial class ProductPage : Page
    {
        private IProductRepository _productRepo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AppState.ProductPageState.Products = GetProductData();
                BindMainRepeater();
            }
        }

        public void OnPageStateUpdated(IPageStateBase stateBase)
        {
            BindMainRepeater();
        }

        private void BindMainRepeater()
        {
            MainRepeater.DataSource = AppState.ProductPageState.Products;
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
                    productCard.ItemCommandHandler -= UpdateSomething;
                    productCard.ItemCommandHandler += UpdateSomething;
                }
            }
        }

        protected void UpdateSomething(object sender, EventArgs e)
        {
            DebugLabel.Text = "Got And Event";
        }

        protected void MainRepeaterItemCommand(object source, RepeaterCommandEventArgs e)
        {
            var commandName = e.CommandName;
            var idArg = Convert.ToInt32(e.CommandArgument);
            DebugLabel.Text = commandName + idArg.ToString();

            switch (commandName)
            {
                case ProductCardItemCommandArgs.Edit:
                    AppState.ProductPageState.EditModeId = idArg;
                    break;

                case ProductCardItemCommandArgs.Save:
                    break;

                case ProductCardItemCommandArgs.Cancel:
                    AppState.ProductPageState.EditModeId = null;
                    break;

                case ProductCardItemCommandArgs.Delete:
                    break;

                default:
                    break;
            }
        }
    }
}
