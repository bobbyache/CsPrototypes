using RuleEngine.Calculators.Data;
using System.Collections.Generic;
using System.Linq;
using System;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.Calculators.Infrastructure.Data;
using RuleEngine.Calculators.Infrastructure.Calculators.Result;

namespace RuleEngine.Calculators
{
    public class HeldIssuerCountCalculator : ICalculator, IHeldIssuerCountCalculator
    {
        private ICalculatorVisitor visitor;

        public IEnumerable<IdDataItem> SourceData { get; set; }

        public void Accept(ICalculatorVisitor visitor)
        {
            this.visitor = visitor;
        }

        public decimal Calculate()
        {
            if (visitor != null)
                visitor.Visit(this);

            return (decimal)SourceData.Count();
        }
    }
}



