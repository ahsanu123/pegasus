using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Data.SqlClient;
using System.Web.Profile;
using System.Web;
using System.Security.Principal;
using System.Text;
using System.Globalization;
using System.Data.Common;

namespace ProfileAPI.CustomerProviders
{
	public sealed class SqlProfileProvider : ProfileProvider
	{
		private string _applicationName;
		private string _sqlConnectionString;
		private string _tableName = "Profiles";

		public override string ApplicationName
		{
			get
			{
				return _applicationName;
			}
			set
			{
				_applicationName = value;
			}
		}

		public override void Initialize(string name, NameValueCollection config)
		{
			// get the config
			if (config == null)
				throw new ArgumentNullException("config is null");

			base.Initialize(name, config);

			// get the application name
			_applicationName = config["applicationName"];
			_sqlConnectionString = config["connectionStringName"];
			if (config["tableName"] != null)
				_tableName = config["tableName"];

			// check for a connection string
			if (_sqlConnectionString == null || _sqlConnectionString.Length < 1)
				throw new ProviderException("The ConnectionString must be specified.");

			// remove recognized attributes
			config.Remove("tableName");
			config.Remove("commandTimeout");
			config.Remove("connectionStringName");
			config.Remove("applicationName");
			config.Remove("description");
			
			// throw if unrecognized attributes are specified
			if (config.Count > 0)
			{
				string attribUnrecognized = config.GetKey(0);
				if (!String.IsNullOrEmpty(attribUnrecognized))
					throw new ProviderException(String.Format("The attribute {0} specified in web.config is not allowed. Please remove it.", attribUnrecognized));
			}
		}

		public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
		{
			if (collection == null || collection.Count < 1 || context == null)
				return null;

			string username = GetUsername(context);

			string itemKey = string.Concat("profile-", username);

			if (HttpContext.Current.Items[itemKey] == null)
			{
				// this will ensure the data will be get only time per request
				HttpContext.Current.Items[itemKey] = GetProfileData(collection, username);
			}

			return HttpContext.Current.Items[itemKey] as SettingsPropertyValueCollection;
		}

		private static string GetUsername(SettingsContext context)
		{
			IPrincipal user = HttpContext.Current.User;

			string username = (string)context["UserName"];

			// get the username
			if (String.IsNullOrEmpty(username) && user.Identity.IsAuthenticated)
				username = user.Identity.Name;

			// otherwise, the user is anonymous - unsupported
			if (String.IsNullOrEmpty(username))
				throw new NotSupportedException("Anonymous profiles are not supported");

			return username;
		}

		public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
		{
			string username = GetUsername(context);
			bool userIsAuthenticated = (bool)context["IsAuthenticated"];

			if (username == null || username.Length < 1 || collection.Count < 1)
				return;

			try
			{
				// let's start to compose the query
				StringBuilder sqlCommand = new StringBuilder("IF EXISTS (SELECT 1 FROM ").Append(_tableName);
				sqlCommand.Append(" WHERE Username = @Username) ");

				// parameters used in the query
				List<SqlParameter> parameters = new List<SqlParameter>();
				parameters.Add(new SqlParameter("@Username", username));

				StringBuilder columnsQuery = new StringBuilder();
				StringBuilder valuesQuery = new StringBuilder();
				StringBuilder setQuery = new StringBuilder();
				SqlParameter param;
				DateTime dtParam;

				bool anyItemsToSave = false;
				int count = 0;

				// check for modified items
				foreach (SettingsPropertyValue pp in collection)
				{
					if (pp.IsDirty && !pp.Property.IsReadOnly)
					{
						if (!userIsAuthenticated)
						{
							bool allowAnonymous = (bool)pp.Property.Attributes["AllowAnonymous"];
							if (!allowAnonymous)
								continue;
						}
						anyItemsToSave = true;

						string columnName = pp.Name;
						SqlDbType dbType = Utilities.ConvertFromCLRTypeToSqlDbType(pp.Property.PropertyType);
						
						object value = null;

						// null check
						if (pp.Deserialized && pp.PropertyValue == null)
							value = DBNull.Value;
						else
							value = pp.PropertyValue;

						columnsQuery.Append(", ");
						valuesQuery.Append(", ");
						columnsQuery.Append(columnName);
						string valueParam = "@Value" + count;
						valuesQuery.Append(valueParam);

						param = new SqlParameter(valueParam, dbType);

						if (param.DbType == DbType.DateTime)
						{
							if (DateTime.TryParse(value.ToString(), out dtParam))
								param.Value = Utilities.FormatDateTimeForDbType(dtParam);
							else
								param.Value = DBNull.Value;
						}
						else
							param.Value = value;

						parameters.Add(param);

						if (count > 0)
							setQuery.Append(",");

						setQuery.Append(columnName);
						setQuery.Append("=");
						setQuery.Append(valueParam);

						++count;
					}
				}

				if (!anyItemsToSave)
					return;

				// continue to build the query
				sqlCommand.Append("BEGIN UPDATE ").Append(_tableName).Append(" SET ").Append(setQuery.ToString());
				sqlCommand.Append(" WHERE Username = @Username");

				sqlCommand.Append(" END ELSE BEGIN INSERT ").Append(_tableName);
				sqlCommand.Append(" (Username").Append(columnsQuery.ToString());
				sqlCommand.Append(") VALUES (@Username").Append(valuesQuery.ToString()).Append(") END");

				// esecuzione della query
				SqlHelper.ExecuteNonQuery(_sqlConnectionString, CommandType.Text, sqlCommand.ToString(), parameters.ToArray());
			}
			catch (Exception ex)
			{
				throw new ProviderException("Provider error. See inner exception", ex);
			}
		}

		private SettingsPropertyValueCollection GetProfileData(SettingsPropertyCollection properties, string username)
		{
			SettingsPropertyValueCollection values = new SettingsPropertyValueCollection();

			StringBuilder commandText = new StringBuilder("SELECT t.Username");
			List<SettingsPropertyValue> columns = new List<SettingsPropertyValue>();
			int columnCount = 0;

			// build the query to include the properties
			foreach (SettingsProperty prop in properties)
			{
				SettingsPropertyValue value = new SettingsPropertyValue(prop);
				values.Add(value);
				columns.Add(value);
			
				commandText.Append(", ");
				commandText.Append("t." + prop.Name);

				++columnCount;
			}

			commandText.Append(" FROM " + _tableName + " t WHERE ");
			commandText.Append("t.UserName = @Username");

			SqlParameter param = new SqlParameter("@Username", username);

			using (SqlDataReader reader = SqlHelper.ExecuteReader(_sqlConnectionString, CommandType.Text, commandText.ToString(), new SqlParameter[] { param }))
			{
				if (reader.Read())
				{
					for (int i = 0; i < columns.Count; ++i)
					{
						object val = reader.GetValue(i + 1);

						// null check
						if (!(val == null || val is DBNull))
						{
							columns[i].PropertyValue = val;
							columns[i].IsDirty = false;
							columns[i].Deserialized = true;
						}
					}
				}
			}

			return values;
		}

		#region Not implemented
		public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
		{
			throw new NotSupportedException("The method or operation is not supported.");
		}

		public override int DeleteProfiles(string[] usernames)
		{
			throw new NotSupportedException("The method or operation is not supported.");
		}

		public override int DeleteProfiles(ProfileInfoCollection profiles)
		{
			throw new NotSupportedException("The method or operation is not supported.");
		}

		public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotSupportedException("The method or operation is not supported.");
		}

		public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
		{
			throw new NotSupportedException("The method or operation is not supported.");
		}

		public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotSupportedException("The method or operation is not implemented.");
		}

		public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotSupportedException("The method or operation is not implemented.");
		}
		public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotSupportedException("The method or operation is not implemented.");
		}

		private ProfileInfoCollection GetProfiles(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotSupportedException("The method or operation is not implemented.");
		}
		#endregion

	}
}