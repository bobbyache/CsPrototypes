using SqlLite.Tests.DAL;
using SqlLite.Tests.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLite.Tests.Repositories
{
    public class AttachmentRepository : EntityRepository<Attachment>
    {
        public AttachmentRepository(IConnectionManager connectionManager) :base(connectionManager)
        {

        }

        public AttachmentRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
