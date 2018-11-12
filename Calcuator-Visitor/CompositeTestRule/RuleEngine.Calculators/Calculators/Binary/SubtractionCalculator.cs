using System;
using RuleEngine.Calculators.Infrastructure;

namespace RuleEngine.Calculators.Binary
{
    public class SubtractionCalculator : ICalculator
    {
        private ICalculator calculator1;
        private ICalculator calculator2;

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

        public SubtractionCalculator(ICalculator calculator1, ICalculator calculator2)
        {
            this.calculator1 = calculator1;
            this.calculator2 = calculator2;
        }

        public void Accept(ICalculatorVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public decimal Calculate()
        {
            return calculator1.Calculate() - calculator2.Calculate();
        }
    }
}
