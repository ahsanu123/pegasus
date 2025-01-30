using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;
using WingtipToys.Repository;

namespace WingtipToys.Pages
{
    public partial class Management : System.Web.UI.Page
    {
        private IProductRepository _productRepo { get;set; }
        public Management() { 
            _productRepo =
                Global._containerProvider.ApplicationContainer.Resolve<IProductRepository>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable GetData()
        {
            return null;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void UpdateData(int id)
        {

        }

        public void InsertData()
        {

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void DeleteData(int id)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Product> ListViewGetData()
        {
            var products = _productRepo.GetProducts().GetAwaiter().GetResult(); 
            return products.AsQueryable();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewUpdateItem(int id)
        {
            WingtipToys.Models.Product item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewDeleteItem(int id)
        {

        }
    }
}