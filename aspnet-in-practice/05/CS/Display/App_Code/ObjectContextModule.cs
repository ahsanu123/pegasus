using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectModel;

public class ObjectContextModule: IHttpModule
{
	public void Dispose()
	{
		// nothing
	}

	public void Init(HttpApplication context)
	{
		context.BeginRequest += new EventHandler(context_BeginRequest);
		context.EndRequest += new EventHandler(context_EndRequest);
		context.Error += new EventHandler(context_EndRequest);
	}

	void context_EndRequest(object sender, EventArgs e)
	{
		if (HttpContext.Current.Items["ObjectContext"] != null)
			(HttpContext.Current.Items["ObjectContext"] as NorthwindEntities).Dispose();
	}

	void context_BeginRequest(object sender, EventArgs e)
	{
		HttpContext.Current.Items["ObjectContext"] = new NorthwindEntities();
	}
}