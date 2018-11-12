using RuleEngine.Calculators.Data;
using System.Collections.Generic;
using System.Linq;
using System;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.Calculators.Infrastructure.Data;
using RuleEngine.Calculators.Infrastructure.Calculators.Result;
using RuleEngine.Calculators.Calculators.Set;

namespace RuleEngine.Calculators
{
    public class BenchMarkCalculator : ICalculator, IBenchMarkCalculator
    {
        private ICalculatorVisitor visitor;

        public IEnumerable<IdAndDecimalValueDataItem> BenchMarkData { get; set; }
        public IEnumerable<IdDataItem> IssuerContext { get; set; }
        public IEnumerable<IdAndBooleanValueDataItem> InstrumentContext { get; set; }

        public decimal Calculate()
        {
            if (this.visitor != null)
                visitor.Visit(this);

            if (this.IssuerContext != null)
                return SetOperations.GetIntersection(this.BenchMarkData, this.IssuerContext).Sum(src => src.Value);

            if (this.InstrumentContext != null)
                return SetOperations.GetIntersection(this.BenchMarkData, this.InstrumentContext).Sum(src => src.Value);

            return 0;
        }

        public void Accept(ICalculatorVisitor visitor)
        {
            this.visitor = visitor;
        }
    }
}
