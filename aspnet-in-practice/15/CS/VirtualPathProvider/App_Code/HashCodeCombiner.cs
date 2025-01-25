using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

// wrapping class for System.Web.Util.HashCodeCombiner
namespace ASPNET4InPractice
{

	public class HashCodeCombiner
	{
		private object internalCombiner;
		private static ConstructorInfo constructor;
		private static MethodInfo addObject;
		private static PropertyInfo resultProperty;

		private const BindingFlags flags = BindingFlags.NonPublic |
										   BindingFlags.Public |
										   BindingFlags.Instance;

		static HashCodeCombiner()
		{
			Assembly asm = Assembly.GetAssembly(typeof(System.Web.UI.Page));
			Type hashCodeCombinerType = asm.GetType("System.Web.Util.HashCodeCombiner");
			constructor = hashCodeCombinerType.GetConstructor(flags, null, Type.EmptyTypes, null);
			addObject = hashCodeCombinerType.GetMethod("AddObject", flags, null, new Type[] { typeof(object) }, null);
			resultProperty = hashCodeCombinerType.GetProperty("CombinedHashString", flags);
		}

		public HashCodeCombiner()
		{
			internalCombiner = constructor.Invoke(null);
		}

		public void AddObject(object value)
		{
			addObject.Invoke(internalCombiner, new object[] { value });
		}

		public string CombinedHashString
		{
			get
			{
				return (string)resultProperty.GetValue(internalCombiner, null);
			}
		}
	}
}