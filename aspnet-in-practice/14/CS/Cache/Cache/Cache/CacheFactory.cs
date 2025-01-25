using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Configuration;
using System.Runtime.Caching;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity;

namespace Cache
{
	public static class CacheFactory
	{
		private static IUnityContainer container;

		static CacheFactory()
		{
			container = new UnityContainer();
			var config = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
			config.Containers.Default.Configure(container);
		}

		public static ObjectCache Instance
		{
			get
			{
				return container.Resolve<ICacheBuilder>().GetInstance();
			}
		}
	}
}