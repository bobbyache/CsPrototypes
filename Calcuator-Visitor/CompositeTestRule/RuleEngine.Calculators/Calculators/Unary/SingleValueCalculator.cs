using System;
using RuleEngine.Calculators.Calculators.Base;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.Calculators.Infrastructure.Calculators.Unary;

namespace RuleEngine.Calculators.Calculators.Unary
{
    public class SingleValueCalculator : BaseCalculator, ISingleValueCalculator
    {
        private decimal returnValue = 0;

        public SingleValueCalculator(string shortName) : base(shortName)
        {
        }

        public SingleValueCalculator(string shortName, decimal value) : base(shortName)
        {
            returnValue = value;
        }

        public override decimal Calculate()
        {
            if (visitor != null)
                visitor.Visit(this);

            return returnValue;
        }
    }
}
