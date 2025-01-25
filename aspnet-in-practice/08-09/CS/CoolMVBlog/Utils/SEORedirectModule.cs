using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolMvcBlog.Utils
{
    public class SEORedirectModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        private void context_BeginRequest(object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            var url = context.Request.Url.AbsoluteUri;

            if (!string.IsNullOrEmpty(url.GetExtension()))
                return;

            string newUrl = url.AppendTrailingSlash();

            if (newUrl != context.Request.Url.AbsoluteUri)
                context.Response.RedirectPermanent(newUrl);
        }
    }
}