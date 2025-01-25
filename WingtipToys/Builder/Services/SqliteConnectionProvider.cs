using Microsoft.Data.Sqlite;

namespace WingtipToys.Builder.Services
{
    public interface ISqliteConnectionProvider
    {
        SqliteConnection CreateConnection();
    }

    public class SqliteConnectionProvider : ISqliteConnectionProvider
    {
        private readonly string _connString;

        public SqliteConnectionProvider(string connectionString)
        {
            _connString = connectionString;
        }

        public SqliteConnection CreateConnection()
        {
            return new SqliteConnection(_connString);
        }
    }
}
