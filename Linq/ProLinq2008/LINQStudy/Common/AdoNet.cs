using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQStudy.LinqToSql
{
    public class AdoNet
    {
        public static string ConnectString
        {
            get
            {
                //return @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind; Integrated Security=SSPI";
                return @"Data Source=ROBERTB;Initial Catalog=Northwind;Integrated Security=SSPI";
            }
        }
        public static void ExecuteStatementInDb(string cmd)
        {
            string connection =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;";
            System.Data.SqlClient.SqlConnection sqlConn =
            new System.Data.SqlClient.SqlConnection(connection);

            System.Data.SqlClient.SqlCommand sqlComm =
            new System.Data.SqlClient.SqlCommand(cmd);
            sqlComm.Connection = sqlConn;
            try
            {
                sqlConn.Open();
                Console.WriteLine("Executing SQL statement against database with ADO.NET ...");
                sqlComm.ExecuteNonQuery();
                Console.WriteLine("Database updated.");
            }
            finally
            {
                // Close the connection.
                sqlComm.Connection.Close();
            }
        }

        public static string GetStringFromDb(System.Data.SqlClient.SqlConnection sqlConnection, string sqlQuery)
        {
            if (sqlConnection.State != System.Data.ConnectionState.Open)
            {
                sqlConnection.Open();
            }
            System.Data.SqlClient.SqlCommand sqlCommand =
            new System.Data.SqlClient.SqlCommand(sqlQuery, sqlConnection);
            System.Data.SqlClient.SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            string result = null;
            try
            {
                if (!sqlDataReader.Read())
                {
                    throw (new Exception(
                    String.Format("Unexpected exception executing query [{0}].", sqlQuery)));
                }
                else
                {
                    if (!sqlDataReader.IsDBNull(0))
                    {
                        result = sqlDataReader.GetString(0);
                    }
                }
            }
            finally
            {
                // always call Close when done reading.
                sqlDataReader.Close();
            }
            return (result);
        }
    }
}
