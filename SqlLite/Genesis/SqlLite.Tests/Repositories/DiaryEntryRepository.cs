using SqlLite.Tests.DAL;
using SqlLite.Tests.DTO;
using SqlLite.Tests.FindCriteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLite.Tests.Repositories
{
    public class DiaryEntryRepository : EntityRepository<DiaryEntry>
    {
        public DiaryEntryRepository(IConnectionManager connectionManager) :base(connectionManager)
        {

        }

        public DiaryEntryRepository(string connectionString) : base(connectionString)
        {

        }

        //public IEnumerable<DiaryEntry> Find(string v)
        //{
        //    return this.GetMany<DiaryEntry>(new DiaryEntry { Title = v }, $"select * from DiaryEntry where Title LIKE '%{v}%'");
        //}

        // Important little tutorial on how to use inbuilt sql lite date/time functions for storage.
        // http://www.sqlitetutorial.net/sqlite-date/
        public IEnumerable<DiaryEntry> Find(DiaryEntryFindCriteria findCriteria)
        {
            string sql = "";
            List<string> filterList = new List<string>();

            sql = $"select * from DiaryEntry\n" +
                    "where \n";

            
            if (findCriteria.StartDate != null && findCriteria.EndDate != null)
                filterList.Add(
                    "DateCreated BETWEEN \n" + 
                    $"{findCriteria.StartDate.Value.Ticks} and {findCriteria.EndDate.Value.Ticks}");
            else if (findCriteria.StartDate != null && findCriteria.EndDate == null)
                filterList.Add(
                    "DateCreated >= \n" +
                    $"{findCriteria.StartDate.Value.Ticks}");

            else if (findCriteria.StartDate == null && findCriteria.EndDate != null)
                filterList.Add(
                    "DateCreated < \n" +
                    $"{findCriteria.EndDate.Value.Ticks}");

            if (!string.IsNullOrWhiteSpace(findCriteria.Title))
                filterList.Add( $"Title LIKE '%{findCriteria.Title}%'");

            sql = sql +
                string.Join("AND", filterList);

            return this.GetMany<DiaryEntry>(null, sql);
        }
    }
}
