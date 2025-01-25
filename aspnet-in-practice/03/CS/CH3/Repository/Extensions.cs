using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace Repository
{
	public static class Extensions
	{
		public static void SetModifiedProperties(this ObjectStateEntry entry, params string[] properties)
		{
			foreach (var p in properties)
				entry.SetModifiedProperty(p);
		}
	}
}
