using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.UI;

namespace CustomControls.Databinding
{
	[ParseChildren(true)]
	public class SingleView : CompositeDataBoundControl, INamingContainer
	{
		[Bindable(true)]
		public override object DataSource { get; set; }

		[Browsable(false), PersistenceMode(PersistenceMode.InnerProperty), DefaultValue(typeof(ITemplate), ""), TemplateContainer(typeof(RepeaterItem), BindingDirection.TwoWay)]
		public ITemplate ItemTemplate { get; set; }

		[Browsable(false), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(RepeaterItem)), DefaultValue((string)null)]
		public ITemplate EmptyTemplate { get; set; }

		// this methods will prevent any container tag
		public override void RenderBeginTag(HtmlTextWriter writer)
		{
		}

		public override void RenderEndTag(HtmlTextWriter writer)
		{
		}
		// ***********

		protected override int CreateChildControls(IEnumerable dataSource, bool dataBinding)
		{
			if (ItemTemplate == null)
				throw new ArgumentNullException("ItemTemplate");

			// we need a control container
			RepeaterItem container = new RepeaterItem(0, ListItemType.Item);
			this.Controls.Add(container);
			ItemTemplate.InstantiateIn(container);

			// if databinding is requested, perform it
			if (dataBinding)
			{
				// check for DataSource and EmptyTemplate
				if (DataSource == null)
				{
					if (EmptyTemplate != null)
					{
						this.Controls.Clear();
						EmptyTemplate.InstantiateIn(this);
					}
				}
				else
				{
					container.DataItem = DataSource;
					if (!Page.IsPostBack)
						container.DataBind();
					container.DataItem = null;
				}
			}

			return 1;
		}

		
	}

}
