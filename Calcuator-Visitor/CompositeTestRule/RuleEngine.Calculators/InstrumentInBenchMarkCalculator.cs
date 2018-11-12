using RuleEngine.Calculators.Data;
using System.Collections.Generic;
using System.Linq;
using System;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.Calculators.Infrastructure.Data;
using RuleEngine.Calculators.Infrastructure.Calculators.Result;

namespace RuleEngine.Calculators
{
    public class InstrumentInBenchmarkCalculator : ICalculator, IInstrumentInBenchmarkCalculator
    {
        private ICalculatorVisitor visitor;

        public IEnumerable<IdAndBooleanValueDataItem> ContextualInstruments { get; set; }
        public IEnumerable<IdAndBooleanValueDataItem> ComponentInstruments { get; set; }

        public decimal Calculate()
        {
            if (visitor != null)
                visitor.Visit(this);

            var filteredRecs = ContextualInstruments.Where(src =>
                ComponentInstruments.Any(ptf => ptf.Id == src.Id)
            );
            return (decimal)filteredRecs.Count();
        }

        public void Accept(ICalculatorVisitor visitor)
        {
            this.visitor = visitor;
        }
    }
}
