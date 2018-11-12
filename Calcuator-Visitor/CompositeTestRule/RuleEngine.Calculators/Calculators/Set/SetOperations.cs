using RuleEngine.Calculators.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Calculators.Set
{
    public class SetOperations
    {
        public static IEnumerable<IdAndDecimalValueDataItem> GetIntersection(IEnumerable<IdAndDecimalValueDataItem> items1, 
            IEnumerable<IdAndBooleanValueDataItem> items2)
        {
            return items1.Where(bnc => items2.Any(iss => iss.Id == bnc.Id));
        }

        public static IEnumerable<IdAndDecimalValueDataItem> GetIntersection(IEnumerable<IdAndDecimalValueDataItem> items1,
        IEnumerable<IdDataItem> items2)
        {
            return items1.Where(bnc => items2.Any(iss => iss.Id == bnc.Id));
        }
    }
}
