using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;

namespace Cache.Providers.InMemory
{
	public class MemoryCacheBuilder : ICacheBuilder
	{
		public MemoryCacheBuilder() { }

		public ObjectCache GetInstance()
		{
			return MemoryCache.Default;
		}

		public string DefaultRegionName
		{
			get { throw new NotSupportedException(); }
		}
	}
}