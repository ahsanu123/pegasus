using System;
using System.Web.UI;
using WingtipToys.Models;

namespace WingtipToys.CustomControl
{
    public partial class ProductCard : UserControl
    {
        public Product Product{ get; set; }
        protected void Page_Load(object sender, EventArgs e) { 
            if(!IsPostBack) DataBind(); 
        }
    }
}
