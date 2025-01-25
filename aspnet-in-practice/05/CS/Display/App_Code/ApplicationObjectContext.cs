using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectModel;

public class ApplicationObjectContext
{
	public static NorthwindEntities Current
	{
		get
		{
			return HttpContext.Current.Items["ObjectContext"] as NorthwindEntities;
		}
	}
}