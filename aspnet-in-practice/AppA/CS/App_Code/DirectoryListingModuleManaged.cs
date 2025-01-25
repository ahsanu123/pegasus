using System;
using System.Web;
using System.IO;

public class DirectoryListingModuleManaged : IHttpModule
{
	public void Init(HttpApplication application)
	{
		// register for EndRequest event
		application.EndRequest += new EventHandler(application_EndRequest);
	}

	void application_EndRequest(object sender, EventArgs e)
	{
		HttpContext context = ((HttpApplication)sender).Context;
		{
			// this is true only when no specific page is requested
			if (Path.GetFileName(context.Request.Url.AbsolutePath).Length == 0 ||
				Path.GetFileName(context.Request.Url.AbsolutePath).Equals(Path.GetFileNameWithoutExtension(context.Request.Url.AbsolutePath), StringComparison.InvariantCultureIgnoreCase)
				)
			{
				context.Response.Clear();
				context.Response.Write("<p>This is a custom default page. Add your custom login here.</p>");
				context.Response.End();
			}
		}
	}

	public void Dispose() {/*nothing */}
}