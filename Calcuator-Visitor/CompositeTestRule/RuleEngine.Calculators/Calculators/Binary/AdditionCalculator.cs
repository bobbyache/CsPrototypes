using RuleEngine.Calculators.Calculators.Base;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.Calculators.Infrastructure.Calculators.Binary;
using System.Collections.Generic;
using System;

namespace RuleEngine.Calculators.Binary
{
    public class AdditionCalculator : BaseCalculator, IAdditionCalculator
    {
        public AdditionCalculator(string shortName) : base(shortName)
        {
        }

        public override decimal Calculate()
        {
            if (visitor != null)
                visitor.Visit(this);

            decimal total = 0;

            foreach (ICalculator calculator in this.Calculators)
                total += calculator.Calculate();

            return total;
        }
    }
}
