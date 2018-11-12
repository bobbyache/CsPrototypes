using RuleEngine.Calculators.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Infrastructure.Calculators.Custom
{
    public interface IBenchMarkCalculator : IVisitableCalculator
    {
        IEnumerable<IdAndDecimalValueDataItem> BenchMarkData { get; set; }
        IEnumerable<IdAndBooleanValueDataItem> InstrumentContext { get; set; }
        IEnumerable<IdDataItem> IssuerContext { get; set; }
    }
}
