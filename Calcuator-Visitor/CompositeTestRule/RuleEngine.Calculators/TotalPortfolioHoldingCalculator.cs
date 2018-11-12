using RuleEngine.Calculators.Data;
using RuleEngine.Calculators.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System;
using RuleEngine.Calculators.Infrastructure.Data;
using RuleEngine.Calculators.Infrastructure.Calculators.Result;

namespace RuleEngine.Calculators
{
    public class TotalPortfolioHoldingCalculator : ICalculator, ITotalPortfolioHoldingCalculator
    {
        private ICalculatorVisitor visitor;

        public IEnumerable<IdAndBooleanValueDataItem> InstrumentDataList { get; set; }
        public IEnumerable<IdDataItem> PortfolioDataList { get; set; }
        public IEnumerable<PortfolioInstrumentDecimalDataItem> SourceData { get; set; }

        public void Accept(ICalculatorVisitor visitor)
        {
            this.visitor = visitor;
        }

        public decimal Calculate()
        {
            if (visitor != null)
                visitor.Visit(this);

            var filteredRecs = SourceData.Where(src => PortfolioDataList.Any(ptf => ptf.Id == src.PorfolioId));
            return (decimal)filteredRecs.Sum(src => src.Value);
        }
    }
}
