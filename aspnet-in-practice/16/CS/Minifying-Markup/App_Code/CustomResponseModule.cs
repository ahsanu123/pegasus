using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using System.Web.UI;

namespace ASPNET4InPractice.Chapter14
{
	public class CustomResponseModule : IHttpModule
	{
		public void Dispose()
		{
			// nothing to do
		}

		public void Init(HttpApplication context)
		{
			context.PreRequestHandlerExecute += new EventHandler(AddFilter);
		}

		void AddFilter(object sender, EventArgs e)
		{
			HttpApplication app = (HttpApplication)sender;
			
			// ignore non page and AJAX requests
			if (!(app.Context.CurrentHandler is Page) || !string.IsNullOrEmpty(app.Request["HTTP_X_MICROSOFTAJAX"]))
				return;

			// this is a bug in ASP.NET>3.5, you just need to first access Request.Filter
			Stream filter = app.Response.Filter;

			// and then add our custom Filter
			app.Response.Filter = new ResponseFilter(app.Response.OutputStream);
		}

	}

}