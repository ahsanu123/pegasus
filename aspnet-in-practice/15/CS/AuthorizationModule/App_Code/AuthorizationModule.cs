using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using System.Web.UI;

namespace ASPNET4InPractice
{
	public class AuthorizationModule : IHttpModule
	{
		public void Dispose()
		{
			// nothing to do
		}

		public void Init(HttpApplication context)
		{
			context.AuthorizeRequest += new EventHandler(OnAuthorizeRequest);
		}

		void OnAuthorizeRequest(object sender, EventArgs e)
		{
			HttpApplication app = (HttpApplication)sender;

			// probably you'll implement something more useful than this :)
			if (DateTime.Now.Hour >= 17)
				app.Context.Response.StatusCode = 401;
		}

	}
}