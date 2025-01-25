using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;

public partial class Articles : System.Web.UI.Page, IArticlePage
{
	public int Id { get; set; }
	public string Description { get; set; }

	protected void Page_Load(object sender, EventArgs e)
	{
		IDValue.Text = Id.ToString();
		DescriptionValue.Text = Description;

		string url = Page.GetRouteUrl ("ArticleRoute",
						new RouteValueDictionary {
										 { "Id", 5 },
										 { "Description", "Test-URL" } });

		RoutedLink.NavigateUrl = url;
	}
}