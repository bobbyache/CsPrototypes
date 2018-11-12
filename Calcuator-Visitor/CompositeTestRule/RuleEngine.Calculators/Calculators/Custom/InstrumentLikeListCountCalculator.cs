using System.Collections.Generic;
using System.Linq;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.Calculators.Infrastructure.Data;
using RuleEngine.Calculators.Infrastructure.Calculators.Custom;
using System;

namespace RuleEngine.Calculators.Custom
{
    public class InstrumentLikeListCountCalculator : ICalculator, IInstrumentLikeListCountCalculator
    {
        private ICalculatorVisitor visitor;

        public IEnumerable<IdAndBooleanValueDataItem> LikeInstrumentData { get; set; }
        public IEnumerable<IdAndBooleanValueDataItem> InstrumentData { get; set; }

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

            var filteredRecs = LikeInstrumentData.Where(bnc => InstrumentData.Any(iss => iss.Id == bnc.Id));
            return filteredRecs.Count();
        }

        public void Accept(ICalculatorVisitor visitor)
        {
            this.visitor = visitor;
        }
    }
}
