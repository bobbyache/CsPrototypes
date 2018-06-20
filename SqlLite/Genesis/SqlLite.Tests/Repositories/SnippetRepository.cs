using SqlLite.Tests.DAL;
using SqlLite.Tests.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLite.Tests.Repositories
{
    public class SnippetRepository : EntityRepository<Snippet>
    {
        public SnippetRepository(IConnectionManager connectionManager) :base(connectionManager)
        {

        }

        public SnippetRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
