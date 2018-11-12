using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Data
{
    public class PortfolioHoldingData
    {
        public readonly int PorfolioId;
        public readonly int InstrumentId;
        public readonly double Total;

        public PortfolioHoldingData(int portfolioId, int instrumentId, double total)
        {
            this.PorfolioId = portfolioId;
            this.InstrumentId = instrumentId;
            this.Total = total;
        }
    }
}
