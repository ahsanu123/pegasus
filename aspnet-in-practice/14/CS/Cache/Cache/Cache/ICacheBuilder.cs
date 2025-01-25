using System;
using System.Runtime.Caching;

namespace Cache
{
	public interface ICacheBuilder
	{
		ObjectCache GetInstance();
		string DefaultRegionName{get;}
	}
}