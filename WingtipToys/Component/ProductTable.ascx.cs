using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Autofac;
using Newtonsoft.Json;
using WingtipToys.Models;
using WingtipToys.Repository;

namespace WingtipToys
{
    [ParseChildren(typeof(Control), ChildrenAsProperties = true)]
    public partial class ProductTable : UserControl
    {
        private IProductRepository _productRepo { get; set; }
        private IEnumerable<Product> _products { get; set; } = new List<Product>();
        public ControlCollection Template { get; private set; }

        public ProductTable()
        {
            Template = new ControlCollection(this);
            _productRepo =
                Global._containerProvider.ApplicationContainer.Resolve<IProductRepository>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //foreach (Control control in Template)
            //{
            //    TemplatePlaceholder.Controls.Add(control);
            //}

            Page.RegisterAsyncTask(new PageAsyncTask(LoadData));
        }

        protected Product GetProduct()
        {
            var product = new Product();
            var provider = new FormValueProvider(Page.ModelBindingExecutionContext);

            if (TryUpdateModel<Product>(product, provider))
            {
                return product;
            }
            else
            {
                throw new FormatException("Could not bind model!1");
            }
        }

        private async Task LoadData()
        {
            _products = await _productRepo.GetProducts();

            //ProductRepeater.DataSource = _products;
            //ProductRepeater.DataBind();

            //ProductListView.DataSource = _products.AsQueryable();
            //ProductListView.DataBind();
        }

        private async Task AddProductAsync()
        {
            await _productRepo.AddProduct(
                new Product
                {
                    Id = 0,
                    Name = "Somethink New",
                    Description = "High Quality new",
                    UnitPrice = 100,
                }
            );
            await LoadData();
        }

        protected void HandleOnAdd(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                var product = new Product
                {
                    Id = 0,
                    Name = NameInput.Text,
                    Description = DescriptionInput.Text,
                };

                int price = 0;
                Int32.TryParse(UnitPriceInput.Text, out price);
                product.UnitPrice = price;

                _productRepo.AddProduct(product).GetAwaiter().GetResult();
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }

        protected void HandleOnDelete(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int id = 0;
            Int32.TryParse(button.CommandArgument, out id);

            if (id == 0)
                throw new Exception("Shit cannot get the id");

            _productRepo.DeleteProduct(id).GetAwaiter().GetResult();
            Page.Response.Redirect(Page.Request.Url.ToString());
        }

        protected void HandleOnEdit(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                //ErrorPanel.Visible = true;
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Product> ProductListView_GetData()
        {
            LoadData().GetAwaiter().GetResult();
            return _products.AsQueryable();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ProductListView_UpdateItem(int id)
        {
            Product item = _productRepo.GetProductById(id).GetAwaiter().GetResult();
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                Page.ModelState.AddModelError(
                    "",
                    String.Format("Item with id {0} was not found", id)
                );
                return;
            }
            TryUpdateModel(item);
            if (Page.ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                _productRepo.UpdateProduct(item).GetAwaiter().GetResult();
            }
        }

        protected void name_DataBinding(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
        }
    }
}
