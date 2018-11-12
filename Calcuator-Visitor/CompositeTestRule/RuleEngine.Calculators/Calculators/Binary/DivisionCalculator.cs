using System;
using RuleEngine.Calculators.Infrastructure;

namespace RuleEngine.Calculators.Binary
{
    public class DivisionCalculator : ICalculator
    {
        private ICalculator numeratorCalculator;
        private ICalculator denominatorCalculator;

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

        public DivisionCalculator(ICalculator numeratorCalculator, ICalculator denominatorCalculator)
        {
            this.numeratorCalculator = numeratorCalculator;
            this.denominatorCalculator = denominatorCalculator;
        }

        public decimal Calculate()
        {
            decimal denominator = denominatorCalculator.Calculate();
            decimal numerator = numeratorCalculator.Calculate();

            if (denominator == 0)
                return 0;

            return (numerator / denominator) * 100;
        }

        public void Accept(ICalculatorVisitor visitor)
        {
            throw new NotImplementedException();
        }
    }
}
