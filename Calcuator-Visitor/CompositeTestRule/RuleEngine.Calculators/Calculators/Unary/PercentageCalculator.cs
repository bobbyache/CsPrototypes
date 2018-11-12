using RuleEngine.Calculators.Calculators.Base;
using RuleEngine.Calculators.Infrastructure.Calculators.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Calculators.Unary
{
    public class PercentageCalculator : BaseCalculator, IPercentageCalculator
    {
        public PercentageCalculator(string shortName) : base(shortName)
        {

        }

        public override decimal Calculate()
        {
            return Calculators[0].Calculate() / Calculators[1].Calculate();
        }
    }
}
