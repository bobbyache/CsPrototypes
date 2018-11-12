using RuleEngine.Calculators.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Infrastructure.Calculators.Result
{
    public interface IBenchMarkCalculator
    {
        IEnumerable<IdAndDecimalValueDataItem> BenchMarkData { get; set; }
        IEnumerable<IdAndBooleanValueDataItem> InstrumentContext { get; set; }
        IEnumerable<IdDataItem> IssuerContext { get; set; }

        void Accept(ICalculatorVisitor visitor);
        decimal Calculate();
    }
}
