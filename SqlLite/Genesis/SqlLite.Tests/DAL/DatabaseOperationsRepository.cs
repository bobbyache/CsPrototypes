using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace SqlLite.Tests.DAL
{
    public class DatabaseOperationsRepository
    {
        private readonly IConnectionManager connectionManager;

        public DatabaseOperationsRepository(string connnectionString)
        {
            this.connectionManager = new ConnectionManager(connnectionString);
        }

        public DatabaseOperationsRepository(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public void CreateAndInitialize(string databaseFilePath, string buildCommands)
        {
            SQLiteConnection.CreateFile(databaseFilePath);

            using (var conn = connectionManager.GetConnection())
            {
                conn.Execute(buildCommands);
            }
        }
    }
}
