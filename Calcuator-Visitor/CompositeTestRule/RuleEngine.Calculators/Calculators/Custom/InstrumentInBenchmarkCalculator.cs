using System.Collections.Generic;
using System.Linq;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.Calculators.Infrastructure.Data;
using RuleEngine.Calculators.Infrastructure.Calculators.Custom;
using System;

namespace RuleEngine.Calculators.Custom
{
    public class InstrumentInBenchmarkCalculator : ICalculator, IInstrumentInBenchmarkCalculator
    {
        private ICalculatorVisitor visitor;

        public IEnumerable<IdAndBooleanValueDataItem> ContextualInstruments { get; set; }
        public IEnumerable<IdAndBooleanValueDataItem> ComponentInstruments { get; set; }

        public string ShortName { get { return ""; } }

        public int RuleId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string AggregateName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

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
