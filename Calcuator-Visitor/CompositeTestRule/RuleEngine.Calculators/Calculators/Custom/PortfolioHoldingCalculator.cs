using RuleEngine.Calculators.Calculators.Base;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.Calculators.Infrastructure.Calculators.Custom;
using RuleEngine.Calculators.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RuleEngine.Calculators.Calculators.Custom
{
    public class PortfolioHoldingCalculator : BaseCalculator, IPortfolioHoldingCalculator
    {
        public IEnumerable<IdDataItem> PortfolioDataList { get; set; }
        public IEnumerable<IdAndBooleanValueDataItem> InstrumentDataList { get; set; }
        public IEnumerable<PortfolioInstrumentDecimalDataItem> SourceData { get; set; }

        public bool Abs { get; set; }
        public bool UseUnderlyingInstrument { get; set; }

        public PortfolioHoldingCalculator(string shortName) : base(shortName)
        {

        }

        public override decimal Calculate()
        {
            if (this.visitor != null)
                visitor.Visit(this);

            // NB:
            // Underlying logic could be wrong here... Will probably expect that we also send a list of underlying instruments that are matched
            // to any instrument sent in via the instrumentDataList context list. This way we could match up the instrument with its underlying
            // instrument.
            var filteredRecs = SourceData.Where(src =>
                PortfolioDataList.Any(ptf => ptf.Id == src.PorfolioId) &&
                InstrumentDataList.Any(inst => inst.Id == src.InstrumentId && (!UseUnderlyingInstrument || inst.Value == true)) // Value is IsUnderlying...
            );

            if (Abs)
                return (decimal)filteredRecs.Sum(src => Math.Abs(src.Value));
            else
                return (decimal)filteredRecs.Sum(src => src.Value);
        }
    }
}
