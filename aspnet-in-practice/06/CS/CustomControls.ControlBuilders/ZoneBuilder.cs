using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Collections;

namespace CustomControls.ControlBuilders
{
	public class ZoneBuilder : ControlBuilder
	{
		public override Type GetChildControlType(string tagName, IDictionary attribs)
		{
			// more options here
			if (tagName.Equals("articles", StringComparison.InvariantCultureIgnoreCase))
				return typeof(ArticleView);
			else if (tagName.Equals("box", StringComparison.InvariantCultureIgnoreCase))
				return typeof(Box);

			return null;
		}
	}
}
