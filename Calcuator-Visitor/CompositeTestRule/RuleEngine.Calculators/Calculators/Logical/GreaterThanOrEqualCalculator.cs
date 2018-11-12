using RuleEngine.Calculators.Infrastructure;
using System;

namespace RuleEngine.Calculators.Calculators.Logical
{
    public class GreaterThanOrEqualCalculator : ICalculator
    {
        private ICalculator leftCalculator;
        private ICalculator rightCalculator;

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

        public GreaterThanOrEqualCalculator(ICalculator leftCalculator, ICalculator rightCalculator)
        {
            if (leftCalculator == null || rightCalculator == null)
                throw new ArgumentNullException("Calculators must be provided.");

            this.leftCalculator = leftCalculator;
            this.rightCalculator = rightCalculator;
        }

        public void Accept(ICalculatorVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public decimal Calculate()
        {
            return leftCalculator.Calculate() >= rightCalculator.Calculate() ? 1 : 0;
        }
    }
}
