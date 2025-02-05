using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WingtipToys.Helper;
using WingtipToys.Models;

namespace WingtipToys.CustomControl
{
    public partial class ProductList : UserControl
    {
        private List<Product> _products;
        private int? _editIndex;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
        }

        protected override void LoadControlState(object savedState)
        {
            if (savedState is object[] state)
            {
                DebugLabel.Text = HelperFunction.SerializeObject(state[0]);
                _products =
                    HelperFunction.DeserializeObject<List<Product>>(state[0] as string)
                    ?? new List<Product>();
                _editIndex = (int?)state[1];
            }
        }

        protected override object SaveControlState()
        {
            return new object[] { HelperFunction.SerializeObject(_products), _editIndex };
        }

        public List<Product> Products
        {
            get { return _products ?? new List<Product>(); }
            set
            {
                _products = value;
                BindData();
            }
        }

        protected void BindData()
        {
            MainRepeater.DataSource = _products;
            MainRepeater.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindData();
        }

        protected void MainRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string commandName = e.CommandName;

            if (commandName == "Edit")
            {
                DebugLabel.Text = "Edit";
                _editIndex = index;
            }
            else if (commandName == "Delete")
            {
                DebugLabel.Text = "Delete";
                _editIndex = null;
            }

            BindData();
        }

        protected void MainRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex == _editIndex)
            {
                e.FindControlAs<Control>("PanelEdit").Visible = true;
                e.FindControlAs<Control>("PanelPreview").Visible = false;
            }
            else
            {
                e.FindControlAs<Control>("PanelEdit").Visible = false;
                e.FindControlAs<Control>("PanelPreview").Visible = true;
            }
        }
    }
}
