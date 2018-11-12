using System.Collections.Generic;
using System.Linq;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.Calculators.Infrastructure.Data;
using RuleEngine.Calculators.Calculators.Set;
using RuleEngine.Calculators.Infrastructure.Calculators.Custom;
using RuleEngine.Calculators.Calculators.Base;
using System;

namespace RuleEngine.Calculators.Custom
{
    public class BenchMarkCalculator : BaseCalculator, IBenchMarkCalculator
    {
        public BenchMarkCalculator(string shortName) : base(shortName)
        {

        }

        public IEnumerable<IdAndDecimalValueDataItem> BenchMarkData { get; set; }
        public IEnumerable<IdDataItem> IssuerContext { get; set; }
        public IEnumerable<IdAndBooleanValueDataItem> InstrumentContext { get; set; }

        public override decimal Calculate()
        {
            if (this.visitor != null)
                visitor.Visit(this);

            if (this.IssuerContext != null)
                return SetOperations.GetIntersection(this.BenchMarkData, this.IssuerContext).Sum(src => src.Value);

            if (this.InstrumentContext != null)
                return SetOperations.GetIntersection(this.BenchMarkData, this.InstrumentContext).Sum(src => src.Value);

            return 0;
        }
    }
}
