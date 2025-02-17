using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            // int index = Convert.ToInt32(e.CommandArgument);
            int index = e.Item.ItemIndex;
            string commandName = e.CommandName;
            DebugLabel.Text = index.ToString();

            if (commandName == "Edit")
            {
                // _editIndex = index;
            }
            else if (commandName == "Delete")
            {
                _editIndex = null;
            }
            else if (commandName == "Save")
            {
                _editIndex = null;
            }
            else if (commandName == "Cancel")
            {
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
