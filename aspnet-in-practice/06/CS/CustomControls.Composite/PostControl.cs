using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace CustomControls.Composite
{
	public class PostControl : WebControl, IPostBackEventHandler
	{
		public DateTime Value
		{
			get
			{
				return (DateTime)(ViewState["Value"] ?? DateTime.MinValue);
			}
			set
			{
				ViewState["Value"] = value;
			}
		}

		protected override void RenderContents(HtmlTextWriter writer)
		{
			string postBackLink = Page.ClientScript.GetPostBackClientHyperlink(this, Value.ToString(), true);
			HyperLink link = new HyperLink();
			link.NavigateUrl = postBackLink;
			link.Text = "Test PostBack";
			link.RenderControl(writer);
		}

		public void RaisePostBackEvent(string eventArgument)
		{
			// get the value from post back - your multiple postback params logic here
			Value = DateTime.Parse(eventArgument);

			// fire the event
			OnValueChanged(EventArgs.Empty);
		}

		public event EventHandler ValueChanged;

		protected void OnValueChanged(EventArgs e)
		{
			if (ValueChanged != null)
				ValueChanged(this, e);
		}

	}
}