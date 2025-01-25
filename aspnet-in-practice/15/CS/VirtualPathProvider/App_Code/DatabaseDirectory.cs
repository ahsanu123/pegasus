using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Collections;

namespace ASPNET4InPractice
{
	public class DatabaseDirectory : VirtualDirectory
	{
		private List<string> _directories = new List<string>();
		private List<string> _files = new List<string>();
		private List<string> _children = new List<string>();

		public DatabaseDirectory(string virtualPath): base(virtualPath)	{}

		public override IEnumerable Children
		{
			get
			{
				return _children;
			}
		}

		public override IEnumerable Directories
		{
			get
			{
				return _directories;
			}
		}

		public override IEnumerable Files
		{
			get
			{
				return _files;
			}
		}
	}
}