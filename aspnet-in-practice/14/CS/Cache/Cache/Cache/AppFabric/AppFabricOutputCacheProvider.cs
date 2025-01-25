using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;
using Cache;
using Microsoft.ApplicationServer.Caching;
using System.Web.Caching;

namespace Cache.Providers.AppFabric
{
	public class AppFabricOutputCacheProvider : OutputCacheProvider
	{
		static AppFabricCacheProvider provider = new AppFabricCacheProvider();

		public override object Add(string key, object entry, DateTime utcExpiry)
		{
			Set(key, entry, utcExpiry);			
			return entry;
		}

		public override object Get(string key)
		{
			return provider.Get(key);
		}

		public override void Remove(string key)
		{
			provider.Remove(key);
		}

		public override void Set(string key, object entry, DateTime utcExpiry)
		{
			provider.Set(key, entry, new CacheItemPolicy { AbsoluteExpiration = utcExpiry.ToLocalTime() });
		}
	}
}