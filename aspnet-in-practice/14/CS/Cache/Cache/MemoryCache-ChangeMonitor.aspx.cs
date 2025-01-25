using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Caching;

public partial class MemoryCache_ChangeMonitor : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		CacheItemPolicy policy = new CacheItemPolicy
		{
			AbsoluteExpiration = DateTime.Now.AddHours(1),
			SlidingExpiration = ObjectCache.NoSlidingExpiration,
			
			Priority = CacheItemPriority.Default,
			ChangeMonitors = {
				new HostFileChangeMonitor(new List<String> { 
				  Server.MapPath("file.txt")
				}) 
			  }
		};
		MemoryCache.Default.Add("cacheKey", DateTime.Now, policy, null);

		Value.Text = MemoryCache.Default["cacheKey"].ToString();

	}
}