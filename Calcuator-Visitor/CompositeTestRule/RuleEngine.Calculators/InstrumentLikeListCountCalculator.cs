using RuleEngine.Calculators.Data;
using System.Collections.Generic;
using System.Linq;
using System;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.Calculators.Infrastructure.Data;
using RuleEngine.Calculators.Infrastructure.Calculators.Result;

namespace RuleEngine.Calculators
{
    public class InstrumentLikeListCountCalculator : ICalculator, IInstrumentLikeListCountCalculator
    {
        private ICalculatorVisitor visitor;

        public IEnumerable<IdAndBooleanValueDataItem> LikeInstrumentData { get; set; }
        public IEnumerable<IdAndBooleanValueDataItem> InstrumentData { get; set; }

        public decimal Calculate()
        {
            if (visitor != null)
                visitor.Visit(this);

            var filteredRecs = LikeInstrumentData.Where(bnc => InstrumentData.Any(iss => iss.Id == bnc.Id));
            return filteredRecs.Count();
        }

        public void Accept(ICalculatorVisitor visitor)
        {
            this.visitor = visitor;
        }
    }
}
