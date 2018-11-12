using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Infrastructure.Data
{
    public class PortfolioInstrumentDataItem
    {
        public readonly int PorfolioId;
        public readonly int InstrumentId;

        public PortfolioInstrumentDataItem(int portfolioId, int instrumentId)
        {
            this.PorfolioId = portfolioId;
            this.InstrumentId = instrumentId;
        }
    }
}
