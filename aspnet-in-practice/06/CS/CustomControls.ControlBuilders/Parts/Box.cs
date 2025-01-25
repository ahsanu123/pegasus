using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace CustomControls.ControlBuilders
{
	// if we inherit from Zone, we can encapsulate other elements as in the main control
	public class Box: Zone
	{
		protected override void Render(HtmlTextWriter writer)
		{
			if (!string.IsNullOrEmpty(Title))
			{
				writer.WriteBeginTag("h2");
				writer.Write(">");
				writer.Write(Title);
				writer.WriteEndTag("h2");
			}

			base.Render(writer);
		}
	}
}
