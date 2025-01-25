using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using VirtualFileSystemModel;

namespace ASPNET4InPractice
{
	internal static class Utility
	{
		internal static string BasePath
		{
			get
			{
				return ConfigurationManager.AppSettings["virtualDirectory"]??"~/";
			}
		}

		internal static bool FileExists(string virtualPath)
		{
			using (VirtualFileSystemEntities ctx = new VirtualFileSystemEntities())
			{
				return ctx.VirtualFiles.Count(x => x.VirtualPath.Equals(virtualPath)) > 0;
			}
		}

		internal static string GetFileContents(string virtualPath)
		{
			using (VirtualFileSystemEntities ctx = new VirtualFileSystemEntities())
			{
				return ctx.VirtualFiles.First(x => x.VirtualPath.Equals(virtualPath)).Contents;
			}
		}

		internal static byte[] GetLastModifiedTimeStamp(string virtualPath)
		{
			using (VirtualFileSystemEntities ctx = new VirtualFileSystemEntities())
			{
				return ctx.VirtualFiles.First(x => x.VirtualPath.Equals(virtualPath)).LastUpdated;
			}
		}
	}
}