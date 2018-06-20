using System.Data;
using System.Data.SQLite;

namespace SqlLite.Tests.DAL
{
    public interface IConnectionManager
    {
        IDbConnection GetConnection();
    }

    public class ConnectionManager : IConnectionManager
    {
        private readonly string connectionString;

        public ConnectionManager(string connectionString)   
        {
            this.connectionString = connectionString;
        }
        public IDbConnection GetConnection()
        {
            var conn = new SQLiteConnection(connectionString);
            return conn;
        }
    }
}
