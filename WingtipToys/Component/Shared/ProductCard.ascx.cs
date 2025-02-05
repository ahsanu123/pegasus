using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Helper;
using WingtipToys.Models;

namespace WingtipToys.CustomControl
{
    public partial class ProductCard : UserControl
    {
        public Product Product{ get; set; }
        protected void Page_Load(object sender, EventArgs e) { 
            //if(!IsPostBack) DataBind(); 
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            Page.Response.RedirectWithQuery("~/EditProductPage", new { id = button.CommandArgument });
        }
    }
}
