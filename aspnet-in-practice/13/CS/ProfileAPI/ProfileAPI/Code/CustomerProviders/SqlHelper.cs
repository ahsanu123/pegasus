using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;

namespace ProfileAPI.CustomerProviders
{
	internal static class SqlHelper
	{
		internal static void ExecuteNonQuery(string sqlConnectionString, CommandType commandType, string query, SqlParameter[] sqlParameter)
		{
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[sqlConnectionString].ConnectionString))
			{
				conn.Open();

				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.CommandType = commandType;
					if (sqlParameter != null && sqlParameter.Length > 0)
						cmd.Parameters.AddRange(sqlParameter);

					cmd.ExecuteNonQuery();
				}
			}
		}

		internal static SqlDataReader ExecuteReader(string sqlConnectionString, CommandType commandType, string query, SqlParameter[] sqlParameter)
		{
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[sqlConnectionString].ConnectionString);
			conn.Open();

			SqlCommand cmd = new SqlCommand(query, conn);

			cmd.CommandType = commandType;
			if (sqlParameter != null && sqlParameter.Length > 0)
				cmd.Parameters.AddRange(sqlParameter);

			return cmd.ExecuteReader(CommandBehavior.CloseConnection);

		}
	}
}