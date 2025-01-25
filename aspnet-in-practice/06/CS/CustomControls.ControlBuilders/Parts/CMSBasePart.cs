using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomControls.ControlBuilders
{
	// base class, used to handle the parts in a similar way
	public class CMSPartBase : WebControl
	{
		protected CMSPartBase():base()
		{

		}

		// more common properties here - use ViewState if needed
		public virtual int PageSize { get; set; }
		public string Title { get; set; }
	}
}