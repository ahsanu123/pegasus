using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace CustomControls.Composite
{
	[DefaultEvent("SelectedValueChanged")]
	public class SimpleInput : Control, IPostBackDataHandler
	{
		public string Text
		{
			get { return ViewState["Text"] as string; }
			set { ViewState["Text"] = value; }
		}

		public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
		{
			if (!postCollection[postDataKey].Equals(Text, StringComparison.InvariantCultureIgnoreCase))
			{
				Text = postCollection[postDataKey];
				return true;
			}
			return false;
		}

		public void RaisePostDataChangedEvent()
		{
			SelectedValueChanged(this, new EventArgs());
		}

		protected override void Render(HtmlTextWriter writer)
		{
			writer.WriteBeginTag("input");
			writer.WriteAttribute("value", Text);
			writer.WriteAttribute("id", ClientID);
			writer.WriteEndTag("input");
		}

		public event EventHandler SelectedValueChanged;

		protected void OnSelectedValueChanged(EventArgs e)
		{
			if (SelectedValueChanged != null)
				SelectedValueChanged(this, e);
		}
	}
}
