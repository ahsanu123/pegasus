using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace ProfileAPI
{
	public class MyProfile : ProfileBase
	{
		// anonymous support is enabled
		[SettingsAllowAnonymous(true)]
		public String FirstName
		{
			get
			{
				return this["FirstName"] as String;
			}
			set
			{
				this["FirstName"] = value;
			}
		}

		[SettingsAllowAnonymous(true)]
		public String LastName
		{
			get
			{
				return base["LastName"] as String;
			}
			set
			{
				base["LastName"] = value;
			}
		}

		[SettingsAllowAnonymous(false)]
		public DateTime? BirthDay
		{
			get
			{
				return base["BirthDay"] as DateTime?;
			}
			set
			{
				base["BirthDay"] = value;
			}
		}
	}
}