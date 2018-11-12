using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Data.Repositories
{
    public class ContextRepository : BaseRepository
    {
        public ContextRepository(string connectionString) : base(connectionString)
        {
        }

        public string GetContextualInstrumentCommaDelimitedIds()
        {
            return base.GetCommaDelimitedIds(GetContextualInstruments());
        }

        public DataTable GetContextualInstruments()
        {
            var sql =
                "SELECT TOP 40 IdKey, Code, [Description] " +
                "FROM " +
                "	dbo.Instrument " +
                "WHERE " +
                "	IdKey > 0 " +
                "	AND " +
                "	IdKey % 2 = 0 ";

            return base.Fetch(sql);
        }

        public int[] GetAllowedInstrumentIds(int ruleId)
        {
            return new int[] { 345, 346, 347 };
        }

        public IEnumerable<Tuple<int, int>> GetInstrumentPools(int ruleId)
        {
            IEnumerable<Tuple<int, int>> instrumentPools = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(2, 345),
                new Tuple<int, int>(2, 346),
                new Tuple<int, int>(4, 445),
                new Tuple<int, int>(5, 347)

            };

            return instrumentPools;
        }

        public IEnumerable<Tuple<int, int, int, int>> GetAggregateData(string aggregateName, IEnumerable<Tuple<int, int>> instrumentPools)
        {
            IEnumerable<Tuple<int, int, int, int>> aggregateData = new List<Tuple<int, int, int, int>>()
            {
                new Tuple<int, int, int, int>(2, 345, 2, 500),
                new Tuple<int, int, int, int>(2, 346, 2, 500),
                new Tuple<int, int, int, int>(4, 347, 3, 500)

            };
            return aggregateData;
        }
    }
}
