using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace CustomControls.ControlBuilders
{
	public class ArticleView : CMSPartBase
	{
		public string Category { get; set; }
		protected override void Render(HtmlTextWriter writer)
		{
			writer.Write("<h1>" + Title + "</h1>");
			writer.Write("<p>This is a list of " + PageSize.ToString() + " articles in " + Category + ".</p>");
		}
	}
}