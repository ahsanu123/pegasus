using System;
using WingtipToys.Builder.Services;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using WingtipToys.Models;
using System.Web.UI.WebControls;

namespace WingtipToys
{
    public partial class About : Page
    {
        // automatic injected by autofac ioc
        public IDummyServices dummyServices { get; set; }
        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void HandleOnSave(object sender, EventArgs e)
        {

        }
    }
}
