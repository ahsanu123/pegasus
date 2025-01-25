using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ASPNET4InPractice
{
	public class ErrorModule: IHttpModule
	{
		public string AdministrativeRole
		{
			get
			{
				// get admnistrative role from web.config
				return ConfigurationManager.AppSettings["admnistrativeRole"];
			}
		}

		public void Dispose()
		{
			// nothing to do
		}

		public void Init(HttpApplication context)
		{
			// register for Error event
			context.Error+=new EventHandler(OnError);
		}

		void OnError(object sender, EventArgs e)
		{
			HttpApplication app = (HttpApplication)sender;
			HttpException ex = app.Server.GetLastError() as HttpException;

			// if user is in AdministrativeRole
			if (app.User.IsInRole(AdministrativeRole))
			{
				// clear Response stream and output error message
				app.Response.Clear();

				// this flag will prevent IIS 7 from displaying its own custom error pages
				app.Response.TrySkipIisCustomErrors = true;

				app.Response.Write(string.Format("<h1>This error is only visible to '{0}' members.</h1>", AdministrativeRole));
				app.Response.Write(ex.GetHtmlErrorMessage());

				// gracefully complete request
				app.Context.ApplicationInstance.CompleteRequest();
			}
		}
	}

}