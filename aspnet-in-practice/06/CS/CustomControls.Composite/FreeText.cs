using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace CustomControls.Composite
{
	[DefaultProperty("Text")]
	[ToolboxData("<{0}:FreeText runat=server text=\"Insert your text here\"></{0}:FreeText>")]
	public class FreeText : Control
	{
		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue("")]
		[Localizable(true)]
		public string Text
		{
			get
			{
				return ViewState["Text"] as String;
			}

			set
			{
				ViewState["Text"] = value;
			}
		}

		protected override void Render(HtmlTextWriter writer)
		{
			writer.Write(Text);
		}
	}
}
