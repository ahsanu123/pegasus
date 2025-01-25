using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomControls.Templated
{
	[ParseChildren(true)]
	public class Message : Control, INamingContainer
	{
		[TemplateContainer(typeof(MessageItem)), PersistenceMode(PersistenceMode.InnerProperty), DefaultValue(typeof(ITemplate), "")]
		public ITemplate ItemTemplate { get; set; }

		public string Text
		{
			get { return ViewState["Text"] as string; }
			set { ViewState["Text"] = value; }
		}

		protected override void CreateChildControls()
		{
			if (ItemTemplate != null)
			{
				MessageItem template = new MessageItem(this);
				ItemTemplate.InstantiateIn(template);
				this.Controls.Clear();
				this.Controls.Add(template);
			}
			else
			{
				Controls.Add(new LiteralControl(Text));
			}
		}

		protected override void OnDataBinding(EventArgs e)
		{
			EnsureChildControls();
			base.OnDataBinding(e);
		}
	}
}
