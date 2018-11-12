using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Data.Repositories
{
    public class PortfolioAttributeRepository : BaseRepository
    {
        public PortfolioAttributeRepository(string connectionString) : base(connectionString)
        {
        }

        public DataTable GetInstrumentContext()
        {
            //return base.Fetch("SELECT * FROM ")
            return null;
        }

        public DataTable GetPortfolioOrCompositeContext()
        {
            return null;
        }


        public decimal[] GetNavAttributeValue(int[] portfolioIds)
        {
            string delimitedPortfolioIds = base.GetCommaDelimitedIds(portfolioIds);

            string sql = GetSql(delimitedPortfolioIds);
            return base.Fetch(GetSql(delimitedPortfolioIds)).AsEnumerable().Select(r => r.Field<decimal>("NAV")).ToArray();
        }

        private string GetSql(string delimitedPortfolioIds)
        {
            return
                "SELECT x.Nav " +
                "FROM ( " +
                "	SELECT " +
                "		dbo.fn_getAttributeValueCurrencyX(537, a.[IdKey], NULL) AS [NAV] " +
                "	FROM dbo.[Portfolio] a " +
                "	WHERE a.IdKey > 0 " +
                "	and a.idkey IN (" + delimitedPortfolioIds +
                "	) ) x " +
                "WHERE NOT (x.[NAV] IS NULL) ";
        }
    }
}
