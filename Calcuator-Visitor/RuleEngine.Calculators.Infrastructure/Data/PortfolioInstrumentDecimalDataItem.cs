using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Infrastructure.Data
{
    public class PortfolioInstrumentDecimalDataItem
    {
        public readonly int PorfolioId;
        public readonly int InstrumentId;
        public readonly decimal Value;

        public PortfolioInstrumentDecimalDataItem(int portfolioId, int instrumentId, decimal value)
        {
            this.PorfolioId = portfolioId;
            this.InstrumentId = instrumentId;
            this.Value = value;
        }
    }
}
