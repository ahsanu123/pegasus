using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.IO;

namespace ASPNET4InPractice
{
	public class DatabaseFile : VirtualFile
	{
		public DatabaseFile(string virtualPath) : base(virtualPath) { }

		public byte[] LastModifiedTimeStamp
		{
			get
			{
				return Utility.GetLastModifiedTimeStamp(VirtualPathUtility.ToAppRelative(VirtualPath));
			}
		}

		public override Stream Open()
		{
			// get file contents and write to the stream
			string fileContents = Utility.GetFileContents(VirtualPathUtility.ToAppRelative(VirtualPath));
			Stream stream = new MemoryStream();
			if (!string.IsNullOrEmpty(fileContents))
			{
				StreamWriter writer = new StreamWriter(stream);
				writer.Write(fileContents);
				writer.Flush();
				stream.Seek(0, SeekOrigin.Begin);
			}
			return stream;
		}
	}
}