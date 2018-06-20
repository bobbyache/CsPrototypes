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

        public IEnumerable<DiaryEntry> FindByTitle(string v)
        {
            return this.GetMany<DiaryEntry>(new DiaryEntry { Title = v }, $"select * from DiaryEntry where Title LIKE '%{v}%'");
        }

        // Important little tutorial on how to use inbuilt sql lite date/time functions for storage.
        // http://www.sqlitetutorial.net/sqlite-date/
        public IEnumerable<DiaryEntry> Find(DiaryEntryFindCriteria findCriteria)
        {
            string sql = $"select * from DiaryEntry where DateCreated BETWEEN {findCriteria.StartDate.Ticks} and {findCriteria.EndDate.Ticks}";
            return this.GetMany<DiaryEntry>(null, sql);
        }
    }
}
