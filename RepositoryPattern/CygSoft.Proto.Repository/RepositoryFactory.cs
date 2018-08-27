using CygSoft.Generic.Repository;
using CygSoft.Generic.Repository.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Proto.Repository
{
    public class RepositoryFactory
    {
        SmartSessionContext context;
        public RepositoryFactory(string connectionString)
        {
            SmartSessionContext context = new SmartSessionContext();
        }
        public IRepository GetRepository()
        {
            return new EntityFrameworkRepository<SmartSessionContext>(context);
        }
    }
}
