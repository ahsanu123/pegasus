using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using ASPNET4InPractice;

public class AppInitializer
{
	public static void AppInitialize()
	{
		HostingEnvironment.RegisterVirtualPathProvider(new DatabasePathProvider());
	}
}