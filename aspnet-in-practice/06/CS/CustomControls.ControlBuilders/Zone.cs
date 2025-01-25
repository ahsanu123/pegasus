using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Collections;
using System.Web.UI.WebControls;

namespace CustomControls.ControlBuilders
{
	[ControlBuilder(typeof(ZoneBuilder))]
	[ParseChildren(false)]
	public class Zone : CMSPartBase
	{
		protected override void RenderContents(HtmlTextWriter writer)
		{
			for (int i = 0; i < this.Controls.Count; i++)
			{
				Controls[i].RenderControl(writer);
			}
		}

		protected override HtmlTextWriterTag TagKey
		{
			get
			{
				return HtmlTextWriterTag.Div;
			}
		}
	}

}
