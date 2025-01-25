using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Configuration;
using System.Web.Caching;

namespace ASPNET4InPractice
{
	public class DatabasePathProvider : VirtualPathProvider
	{
		public DatabasePathProvider() : base()
		{
		}

		public override System.Web.Caching.CacheDependency GetCacheDependency(string virtualPath, System.Collections.IEnumerable virtualPathDependencies, DateTime utcStart)
		{
			if (IsVirtualPath(virtualPath))
				return null;
			
			return base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
		}

		public override string GetFileHash(string virtualPath, System.Collections.IEnumerable virtualPathDependencies)
		{
			HashCodeCombiner hashCodeCombiner = new HashCodeCombiner();

			List<string> unrecognizedDependencies = new List<string>();

			foreach (string virtualDependency in virtualPathDependencies)
			{
				if (IsVirtualPath(virtualDependency))
				{
					DatabaseFile file = (DatabaseFile)GetFile(virtualDependency);
					hashCodeCombiner.AddObject(file.LastModifiedTimeStamp);
				}
				else
				{
					unrecognizedDependencies.Add(virtualDependency);
				}
			}

			string result = hashCodeCombiner.CombinedHashString;

			if (unrecognizedDependencies.Count > 0)
			{
				result += Previous.GetFileHash(virtualPath, unrecognizedDependencies);
			}

			return result;
		}

		private bool IsVirtualPath(string virtualPath)
		{
			return VirtualPathUtility.ToAppRelative(virtualPath).StartsWith(Utility.BasePath, StringComparison.InvariantCultureIgnoreCase);
		}

		public override bool FileExists(string virtualPath)
		{
			if (IsVirtualPath(virtualPath) && Utility.FileExists(VirtualPathUtility.ToAppRelative(virtualPath)))
				return true;

			return Previous.FileExists(virtualPath);
		}

		public override bool DirectoryExists(string virtualDir)
		{
			if (IsVirtualPath(virtualDir))
				return true;

			return Previous.DirectoryExists(virtualDir);
		}

		public override VirtualFile GetFile(string virtualPath)
		{
			if (IsVirtualPath(virtualPath))
				return new DatabaseFile(virtualPath);
			else
				return Previous.GetFile(virtualPath);
		}

		public override VirtualDirectory GetDirectory(string virtualDir)
		{
			if (IsVirtualPath(virtualDir))
				return new DatabaseDirectory(virtualDir);
			else
				return Previous.GetDirectory(virtualDir);
		}


	}
}