using RuleEngine.Calculators.Binary;
using RuleEngine.Calculators.Calculators.Base;
using RuleEngine.Calculators.Calculators.Custom;
using RuleEngine.Calculators.Calculators.Unary;
using RuleEngine.Calculators.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Calculators
{
    internal class CalculatorMapper
    {
        public BaseCalculator Create(string shortName)
        {
            switch (shortName)
            {
                case "percentage": return new PercentageCalculator(shortName);
                case "plus": return new AdditionCalculator(shortName);
                case "portfolioholding": return new PortfolioHoldingCalculator(shortName);
                case "portfolioholdingwithcontext": return new PortfolioHoldingWithContextCalculator(shortName);
                case "portfolioattributevalue": return new PortfolioAttributeValueCalculator(shortName);

                default: throw new Exception("Calculator could not be resolved from the calculator name supplied.");
            }
        }
    }
}
