using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Data.Repositories
{

    public abstract class BaseRepository
    {
        private string connectionString;

        public BaseRepository(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("A valid connection string must be provided.");

            this.connectionString = connectionString;
        }

        protected DataTable Fetch(string sql)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = sql;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable("DataTable");
                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }

        protected string GetCommaDelimitedIds(DataTable dataTable, string fieldName = "IdKey")
        {
            var ids = dataTable.AsEnumerable().Select(d => d.Field<int>(fieldName)).ToArray();
            return string.Join(",", ids);
        }

        protected string GetCommaDelimitedIds(int[] ids)
        {
            return string.Join(",", ids);
        }
    }
}
