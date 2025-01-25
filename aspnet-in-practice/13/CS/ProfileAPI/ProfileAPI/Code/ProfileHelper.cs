using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace ProfileAPI
{
	public class ProfileHelper
	{
		public static string GetFirstName()
		{
			return ((MyProfile)HttpContext.Current.Profile).FirstName;
		}
	}
}