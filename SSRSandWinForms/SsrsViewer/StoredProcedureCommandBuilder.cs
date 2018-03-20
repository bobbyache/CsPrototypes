//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SsrsViewer
//{
//    public class StoredProcedureCommandBuilder : IDisposable
//    {
//        private bool _isDisposed;

//        public SqlCommand Command { get; }

//        public StoredProcedureCommandBuilder(string storedProcedureName, SqlConnection connection)
//        {
//            Command = new SqlCommand(storedProcedureName, connection) { CommandType = CommandType.StoredProcedure };
//        }

//        ~StoredProcedureCommandBuilder()
//        {
//            Dispose(false);
//        }

//        public void AddParameter<T>(string parameterName, T value)
//        {
//            var type = typeof(T);
//            var databaseType = GetDatabaseType(type);
//            var parameter = GetParameter(parameterName, databaseType, value);

//            Command.Parameters.Add(parameter);
//        }

//        private static SqlParameter GetParameter(string parameterName, SqlDbType databaseType, object value)
//        {
//            var parameter = new SqlParameter(parameterName, databaseType) { Value = value ?? DBNull.Value };
//            return parameter;
//        }

//        private static SqlDbType GetDatabaseType(Type type)
//        {
//            switch (type.Name)
//            {
//                case "System.String":
//                    return SqlDbType.NVarChar;
//                case "System.DateTime":
//                    return SqlDbType.DateTime;
//                case "System.Int32":
//                    return SqlDbType.Int;
//                default:
//                    return SqlDbType.NVarChar;
//            }
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }

//        protected virtual void Dispose(bool disposing)
//        {
//            if (!_isDisposed)
//            {
//                if (disposing)
//                {
//                    Command.Dispose();
//                }
//            }
//            _isDisposed = true;
//        }
//    }
//}
