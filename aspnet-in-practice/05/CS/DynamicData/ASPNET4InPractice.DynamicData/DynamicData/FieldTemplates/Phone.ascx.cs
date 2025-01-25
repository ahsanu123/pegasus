using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNET4InPractice.DynamicData
{
	public partial class PhoneField : System.Web.DynamicData.FieldTemplateUserControl
	{
		protected override void OnDataBinding(EventArgs e)
		{
			HyperLinkUrl.NavigateUrl = GetUrl(FieldValueString);
		}

		private string GetUrl(string phone)
		{
			return string.IsNullOrEmpty(phone) ? "#" : string.Concat("callto:", phone);
		}

		public override Control DataControl
		{
			get
			{
				return HyperLinkUrl;
			}
		}
	}
}
