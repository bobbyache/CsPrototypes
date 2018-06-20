using SqlLite.Tests.DAL;
using System.IO;
using System.Reflection;
using System.Text;
using Dapper;
using Dapper.Contrib.Extensions;

namespace SqlLite.Tests
{
    public class DbFile
    {
        public static string GetPath(string fileName)
        {
            string folder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Files");
            return Path.Combine(folder, fileName);
        }

        public static string GetConnectionString(string fileName)
        {
            string path = GetPath(fileName);
            return $"Data Source={path};Version=3;New=False;Compress=True;";
        }

        //public static void CreateDatabase(string fileName)
        //{
        //    SQLiteConnection.CreateFile("MyDatabase.sqlite");
        //}

        //public static void RebuildDatabase(IConnectionManager connectionManager)
        //{
        //    using (var conn = connectionManager.GetConnection() )
        //    {
        //        conn.Open();
        //        var result = conn.ExecuteNonQuery(
        //            TxtFile.ReadText("RebuildDatabase.txt"));
        //    }
        //}
    }
}
