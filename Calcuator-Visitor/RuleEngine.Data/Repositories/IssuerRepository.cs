using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Data.Repositories
{
    public class IssuerRepository : BaseRepository
    {
        public IssuerRepository(string connectionString) : base(connectionString) { }

        public DataTable GetAggregates(string delimitedInstrumentIds)
        {
            string sql = GetAggregateSql(delimitedInstrumentIds);
            return base.Fetch(sql);
        }

        private string GetAggregateSql(string delimitedInstrumentIds)
        {
            // Query condensed into a single query.
            return
                "SELECT IdKey, " +
                "	TIMESTAMP, " +
                "	Code, " +
                "	Description " +
                "FROM dbo.[Issuer] " +
                "WHERE " +
                "	IdKey IN " +
                "	( " +
                "		SELECT " +
                "			( " +
                "				CASE " +
                "					WHEN a.IssuerCode IS NULL THEN - 1 " +
                "					ELSE a.IssuerCode " +
                "				END " +
                "			) AS AggregateId " +
                "		FROM " +
                "			dbo.gvw_InstrumentAttributes a " +
                "		WHERE " +
                "			a.IdKey > 0 " +
                "			AND a.IdKey IN (SELECT Id FROM dbo.fn_SplitIds('" + delimitedInstrumentIds + "', ',')) " +
                "	) " +
                "ORDER BY Code ";
        }
    }
}
