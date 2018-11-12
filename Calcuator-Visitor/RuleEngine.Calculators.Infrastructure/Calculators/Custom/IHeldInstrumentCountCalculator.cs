using RuleEngine.Calculators.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Infrastructure.Calculators.Custom
{
    public interface IHeldInstrumentCountCalculator : IVisitableCalculator
    {
        IEnumerable<IdAndBooleanValueDataItem> InstrumentContext { get; set; }
        IEnumerable<IdDataItem> PortfolioContext { get; set; }
        IEnumerable<PortfolioInstrumentDataItem> SourceData { get; set; }
    }
}
