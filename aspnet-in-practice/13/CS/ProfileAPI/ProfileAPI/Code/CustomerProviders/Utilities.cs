using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration.Provider;
using System.Configuration;
using System.Data;
using System.Globalization;

namespace ProfileAPI.CustomerProviders
{
	internal static class Utilities
	{
		internal static object FormatDateTimeForDbType(DateTime value)
		{
			return (value.Year <= 1754) ? (object)DBNull.Value : (object)value.ToString(DateTimeFormatInfo.InvariantInfo);
		}

		internal static SqlDbType ConvertFromCLRTypeToSqlDbType(Type propType)
		{
			if (propType.Equals(typeof(string)))
				return SqlDbType.VarChar;
			else if (propType.Equals(typeof(Int16)) || propType.Equals(typeof(Int32)))
				return SqlDbType.Int;
			else if (propType.Equals(typeof(DateTime)) || propType.Equals(typeof(DateTime?)))
				return SqlDbType.DateTime;
			else if (propType.Equals(typeof(Decimal)))
				return SqlDbType.Decimal;
			else if (propType.Equals(typeof(double)) || propType.Equals(typeof(float)))
				return SqlDbType.Float;
			else if (propType.Equals(typeof(bool)))
				return SqlDbType.Bit;

			// add others if needed
			return SqlDbType.Variant;
		}

		internal static void HasValidName(string name)
		{
			string legalChars = "_@#$";
			for (int i = 0; i < name.Length; ++i)
			{
				if (!Char.IsLetterOrDigit(name[i]) && legalChars.IndexOf(name[i]) == -1)
					throw new ProviderException("Table and column names cannot contain: " + name[i]);
			}
		}
	}

}