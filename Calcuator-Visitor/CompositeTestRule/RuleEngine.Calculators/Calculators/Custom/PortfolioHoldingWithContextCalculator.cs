using RuleEngine.Calculators.Calculators.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Calculators.Custom
{
    public class PortfolioHoldingWithContextCalculator : BaseCalculator
    {
        public PortfolioHoldingWithContextCalculator(string shortName) : base(shortName)
        {
        }

        public override decimal Calculate()
        {
            return 0;
            ///throw new NotImplementedException();
        }
    }
}
