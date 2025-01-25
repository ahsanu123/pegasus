using System.Web.Configuration;
using System.Web;
using System;
using System.Collections;
using System.Web.Caching;

namespace ASPNET4InPractice
{
    public class MyBrowserProvider : HttpCapabilitiesProvider
    {
        public override HttpBrowserCapabilities GetBrowserCapabilities(HttpRequest request)
        {
            string cacheKey = "MyBrowserProvider_"+ request.UserAgent??"empty";
            int cacheTimeout = 360;

            HttpBrowserCapabilities browserCaps = HttpContext.Current.Cache[cacheKey] as HttpBrowserCapabilities;
            if (browserCaps == null)
            {
                browserCaps = new HttpBrowserCapabilities();
                Hashtable values = new Hashtable(20, StringComparer.OrdinalIgnoreCase);
                values["browser"] = request.UserAgent;
                values["tables"] = "true";
                values["supportsRedirectWithCookie"] = "true";
                values["cookies"] = "true";
                values["ecmascriptversion"] = "3.0";
                values["w3cdomversion"] = "1.0";
                values["jscriptversion"] = "6.0";
                values["tagwriter"]= "System.Web.UI.HtmlTextWriter";

                values["IsIPhone"] = ((request.UserAgent ?? string.Empty).IndexOf("iphone") > -1).ToString();

                browserCaps.Capabilities = values;
                HttpRuntime.Cache.Add(cacheKey, browserCaps, null, DateTime.Now.AddSeconds(cacheTimeout), TimeSpan.Zero, CacheItemPriority.Low, null);
            }

            return browserCaps;
        }
    }
}