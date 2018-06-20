using SqlLite.Tests.DAL;
using SqlLite.Tests.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLite.Tests.Repositories
{
    public class HyperlinkRepository : EntityRepository<Hyperlink>
    {
        public HyperlinkRepository(IConnectionManager connectionManager) :base(connectionManager)
        {

        }

        public HyperlinkRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
