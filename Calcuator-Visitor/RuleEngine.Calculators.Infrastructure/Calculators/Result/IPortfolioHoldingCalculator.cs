using RuleEngine.Calculators.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Infrastructure.Calculators.Result
{
    public interface IPortfolioHoldingCalculator
    {
        bool Abs { get; set; }
        IEnumerable<IdAndBooleanValueDataItem> InstrumentDataList { get; set; }
        IEnumerable<IdDataItem> PortfolioDataList { get; set; }
        IEnumerable<PortfolioInstrumentDecimalDataItem> SourceData { get; set; }
        bool UseUnderlyingInstrument { get; set; }

        void Accept(ICalculatorVisitor visitor);
        decimal Calculate();
    }
}
