using RuleEngine.Calculators.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Infrastructure.Calculators.Result
{
    public interface IHeldInstrumentCountCalculator
    {
        IEnumerable<IdAndBooleanValueDataItem> InstrumentContext { get; set; }
        IEnumerable<IdDataItem> PortfolioContext { get; set; }
        IEnumerable<PortfolioInstrumentDataItem> SourceData { get; set; }

        void Accept(ICalculatorVisitor visitor);
        decimal Calculate();
    }
}
