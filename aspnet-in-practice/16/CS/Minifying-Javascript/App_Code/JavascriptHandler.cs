using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.IO;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.Web.Caching;

namespace ASPNET4InPractice.Chapter14
{
	public class JavascriptHandler : IHttpHandler
	{
		public bool IsReusable
		{
			// true if you have no instance specific information
			get { return true; }
		}

		public void ProcessRequest(HttpContext context)
		{
			string fileContent = string.Empty;
			string filePath = context.Request.PhysicalPath;
			string cacheKey = string.Concat("js-", filePath);
			object cacheValue = context.Cache[cacheKey];
			
			// check for cache
			if (cacheValue == null)
				fileContent = AddInCache(filePath, cacheKey);
			else
			    fileContent = cacheValue as string;

			// set the appropriate content type
			context.Response.ContentType = "text/javascript";
			context.Response.Write(fileContent);
		}

		private static string AddInCache(string filePath, string cacheKey)
		{
			// then write out the file
			string fileContent = File.ReadAllText(filePath);

			// this will remove comments
			fileContent = Regex.Replace(fileContent, @"(?mi)(/\*[\d\D]*?\*/)|(//.*$)", string.Empty);

			// this will normalize scripts
			fileContent = Regex.Replace(fileContent, "\t", string.Empty);
			fileContent = Regex.Replace(fileContent, "\r\n", string.Empty);
			fileContent = Regex.Replace(fileContent, "\r", string.Empty);
			fileContent = Regex.Replace(fileContent, "\n", string.Empty);

			// this will remove more than 2 spaces sequences
			fileContent = Regex.Replace(fileContent, "[ ]{2,}", string.Empty);

			// add a mark
			fileContent = string.Concat("/* minifyed at ", DateTime.Now, "*/ ", fileContent);

			// add to cache for 2 hours
			HttpContext.Current.Cache.Insert(cacheKey, fileContent, new CacheDependency(filePath), DateTime.Now.AddHours(2), TimeSpan.Zero);

			return fileContent;
		}

	}

}