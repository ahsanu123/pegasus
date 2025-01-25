using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Data {
	static class Extensions {
		public static Nullable<T> GetNullable<T>(this DbDataReader reader, string fieldName) where T : struct{
			var ordinal = reader.GetOrdinal(fieldName);
			if (reader[ordinal] is DBNull)
				return null;
			else
				return (T)reader[ordinal];
		}
		public static T Get<T>(this DbDataReader reader, string fieldName) {
			var ordinal = reader.GetOrdinal(fieldName);
			if (reader[ordinal] is DBNull)
				return (T)Convert.ChangeType(null, typeof(T));
			else
				return (T)reader[ordinal];
		}
	}
}
