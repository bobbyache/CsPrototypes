using System.Collections.Generic;
using System.Linq;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.Calculators.Infrastructure.Data;
using RuleEngine.Calculators.Infrastructure.Calculators.Custom;
using RuleEngine.Calculators.Calculators.Base;
using System;

namespace RuleEngine.Calculators.Custom
{
    public class HeldInstrumentCountCalculator : BaseCalculator, IHeldInstrumentCountCalculator
    {
        public IEnumerable<PortfolioInstrumentDataItem> SourceData { get; set; }
        public IEnumerable<IdDataItem> PortfolioContext { get; set; }
        public IEnumerable<IdAndBooleanValueDataItem> InstrumentContext { get; set; }

        public HeldInstrumentCountCalculator(string shortName) : base(shortName)
        {

        }

        public override decimal Calculate()
        {
            if (this.visitor != null)
                visitor.Visit(this);

            var filteredRecs = SourceData.Where(src =>
                PortfolioContext.Any(ptf => ptf.Id == src.PorfolioId) &&
                InstrumentContext.Any(inst => inst.Id == src.InstrumentId)
            );
            return (decimal)filteredRecs.Count();
        }
    }
}
