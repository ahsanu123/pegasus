using System;
using System.Web;
using System.Web.UI;

namespace ASPNET4InPractice
{
	public class MobileModule : IHttpModule
	{
		public void Dispose()
		{
			// nothing
		}

		public void Init(HttpApplication context)
		{
			context.PreRequestHandlerExecute += new EventHandler(CheckMobileRequest);
		}

		void CheckMobileRequest(object sender, EventArgs e)
		{
			HttpApplication app = sender as HttpApplication;

			// if the request is coming from a mobile device, mark it
			if (app.Request.Browser.IsMobileDevice)
			{
				app.Context.Items["isMobile"] = true;
				ModifyMasterPage(app);
			}
		}

		private void ModifyMasterPage(HttpApplication app)
		{
			if (app.Context.Handler is Page)
			{
				((Page)app.Context.Handler).PreInit += new EventHandler(ApplyMasterPage);
			}
		}

		private void ApplyMasterPage(object sender, EventArgs e)
		{
			((Page)sender).MasterPageFile = "~/Masters/Mobile.master";
		}
		
	}
}