using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomControls.Web
{
	public partial class SingleView : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			// test the EmptyTemplate
			AuthorView.DataSource = null;

			// test the ItemTemplate
			//AuthorView.DataSource = new Author { FirstName = "Daniele", LastName = "Bochicchio" };

			AuthorView.DataBind();
		}
	}

	public class Author
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}