using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;
using Cache;
using Microsoft.ApplicationServer.Caching;

namespace Cache.Providers.AppFabric
{
	public class AppFabricCacheProvider : ObjectCache, ICacheBuilder
	{
		public static DataCache factory = null;
		public static object syncObj = new object();

		public override object AddOrGetExisting(string key, object value, CacheItemPolicy policy, string regionName = null)
		{
			CacheItem item = GetCacheItem(key, regionName);
			if (item == null)
			{
				Set(new CacheItem(key, value, regionName), policy);
				return value;
			}

			return item.Value;
		}

		public override CacheItem AddOrGetExisting(CacheItem value, CacheItemPolicy policy)
		{
			CacheItem item = GetCacheItem(value.Key, value.RegionName);
			if (item == null)
			{
				Set(value, policy);
				return value;
			}

			return item;
		}

		public override object AddOrGetExisting(string key, object value, System.DateTimeOffset absoluteExpiration, string regionName = null)
		{
			CacheItem item = new CacheItem(key, value, regionName);
			CacheItemPolicy policy = new CacheItemPolicy();
			policy.AbsoluteExpiration = absoluteExpiration;

			return AddOrGetExisting(item, policy);
		}

		public override bool Contains(string key, string regionName = null)
		{
			return Get(key, regionName) != null;
		}

		public override CacheEntryChangeMonitor CreateCacheEntryChangeMonitor(System.Collections.Generic.IEnumerable<string> keys, string regionName = null)
		{
			throw new NotImplementedException();
		}

		public override DefaultCacheCapabilities DefaultCacheCapabilities
		{
			get
			{
				return
					DefaultCacheCapabilities.OutOfProcessProvider |
					DefaultCacheCapabilities.AbsoluteExpirations |
					DefaultCacheCapabilities.SlidingExpirations |
					DefaultCacheCapabilities.CacheRegions;
			}
		}

		public override object Get(string key, string regionName = null)
		{
			key = key.ToLower();
			CreateRegionIfNeeded();

			return (regionName == null) ?
				CacheFactory.Get(key) :
				CacheFactory.Get(key, regionName);
		}

		public override CacheItem GetCacheItem(string key, string regionName = null)
		{
			object value = Get(key, regionName);
			if (value != null)
				return new CacheItem(key, value, regionName);

			return null;
		}

		public override long GetCount(string regionName = null)
		{
			if (string.IsNullOrEmpty(regionName))
				throw new NotSupportedException();

			return CacheFactory.GetObjectsInRegion(regionName).LongCount();
		}

		protected override System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator()
		{
			throw new NotSupportedException();
		}

		public override System.Collections.Generic.IDictionary<string, object> GetValues(System.Collections.Generic.IEnumerable<string> keys, string regionName = null)
		{
			if (string.IsNullOrEmpty(regionName))
				throw new NotSupportedException();

			return CacheFactory.GetObjectsInRegion(regionName).ToDictionary(x => x.Key, x=> x.Value);
		}

		public override string Name
		{
			get { return "AppFabric"; }
		}

		public override object Remove(string key, string regionName = null)
		{
			key = key.ToLower();
			CreateRegionIfNeeded();

			return (regionName == null) ?
				CacheFactory.Remove(key) :
				CacheFactory.Remove(key, regionName);
		}

		public override void Set(string key, object value, CacheItemPolicy policy, string regionName = null)
		{
			Set(new CacheItem(key, value, regionName), policy);
		}

		public override void Set(CacheItem item, CacheItemPolicy policy)
		{
			if (item == null || item.Value == null)
				return;

			if (policy != null && policy.ChangeMonitors != null && policy.ChangeMonitors.Count>0)
				throw new NotSupportedException("Change monitors are not supported");

			item.Key = item.Key.ToLower();
			CreateRegionIfNeeded();

			TimeSpan expire = (policy.AbsoluteExpiration.Equals(null)) ?
				policy.SlidingExpiration :
				(policy.AbsoluteExpiration - DateTimeOffset.Now);

			if (string.IsNullOrEmpty(item.RegionName))
				CacheFactory.Put(item.Key, item.Value, expire);
			else
				CacheFactory.Put(item.Key, item.Value, expire, item.RegionName);
		}

		private static DataCache CacheFactory
		{
			get
			{
				if (factory == null)
				{
					lock (syncObj)
					{
						if (factory == null)
						{
							DataCacheFactory cacheFactory = new DataCacheFactory();
							factory = cacheFactory.GetDefaultCache();
						}
					}
				}

				return factory;
			}
		}

		private void CreateRegionIfNeeded()
		{
			// if the regione exists, an exception is thrown
			try
			{
				CacheFactory.CreateRegion(DefaultRegionName);
			}
			catch (DataCacheException ex)
			{
				if (!ex.ErrorCode.Equals(DataCacheErrorCode.RegionAlreadyExists))
					throw ex;
			}
		}

		public override void Set(string key, object value, System.DateTimeOffset absoluteExpiration, string regionName = null)
		{
			CacheItem item = new CacheItem(key, value, regionName);
			CacheItemPolicy policy = new CacheItemPolicy();
			policy.AbsoluteExpiration = absoluteExpiration;

			Set(item, policy);
		}

		public override object this[string key]
		{
			get
			{
				return Get(key, DefaultRegionName);
			}
			set
			{
				Set(key, value, null, DefaultRegionName);
			}
		}

		public ObjectCache GetInstance()
		{
			return this;
		}

		public string DefaultRegionName
		{
			get
			{
				// TODO: load from configuration
				return "AppFabric"; 
			}
		}
	}
}