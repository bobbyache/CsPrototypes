using System.Collections.Generic;
using System.Linq;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.Calculators.Infrastructure.Data;
using RuleEngine.Calculators.Infrastructure.Calculators.Custom;
using RuleEngine.Calculators.Calculators.Base;
using System;

namespace RuleEngine.Calculators.Custom
{
    public class HeldIssuerCountCalculator : BaseCalculator, IHeldIssuerCountCalculator
    {
        public IEnumerable<IdDataItem> SourceData { get; set; }

        public HeldIssuerCountCalculator(string shortName) : base(shortName)
        {

        }

        public override decimal Calculate()
        {
            if (visitor != null)
                visitor.Visit(this);

            return (decimal)SourceData.Count();
        }
    }
}



