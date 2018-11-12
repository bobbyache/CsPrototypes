using RuleEngine.Calculators.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Infrastructure.Calculators.Result
{
    public interface IInstrumentInBenchmarkCalculator
    {
        IEnumerable<IdAndBooleanValueDataItem> ComponentInstruments { get; set; }
        IEnumerable<IdAndBooleanValueDataItem> ContextualInstruments { get; set; }

        void Accept(ICalculatorVisitor visitor);
        decimal Calculate();
    }
}
