using RuleEngine.Calculators.Data;
using System.Collections.Generic;
using System.Linq;
using System;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.Calculators.Infrastructure.Data;
using RuleEngine.Calculators.Infrastructure.Calculators.Result;

namespace RuleEngine.Calculators
{
    public class HeldInstrumentCountCalculator : ICalculator, IHeldInstrumentCountCalculator
    {
        private ICalculatorVisitor visitor;

        public IEnumerable<PortfolioInstrumentDataItem> SourceData { get; set; }
        public IEnumerable<IdDataItem> PortfolioContext { get; set; }
        public IEnumerable<IdAndBooleanValueDataItem> InstrumentContext { get; set; }

        public decimal Calculate()
        {
            if (this.visitor != null)
                visitor.Visit(this);

            var filteredRecs = SourceData.Where(src =>
                PortfolioContext.Any(ptf => ptf.Id == src.PorfolioId) &&
                InstrumentContext.Any(inst => inst.Id == src.InstrumentId)
            );
            return (decimal)filteredRecs.Count();
        }

        public void Accept(ICalculatorVisitor visitor)
        {
            this.visitor = visitor;
        }
    }
}
