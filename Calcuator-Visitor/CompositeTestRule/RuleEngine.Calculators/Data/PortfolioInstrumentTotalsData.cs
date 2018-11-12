using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Data
{
    public class PortfolioInstrumentTotalsData
    {
        public readonly int PorfolioId;
        public readonly int InstrumentId;
        public readonly double Total;

        public PortfolioInstrumentTotalsData(int portfolioId, int instrumentId, double total)
        {
            this.PorfolioId = portfolioId;
            this.InstrumentId = instrumentId;
            this.Total = total;
        }
    }
}
