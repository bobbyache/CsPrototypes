using RuleEngine.Calculators.Binary;
using RuleEngine.Calculators.Calculators.Unary;
using System.Collections.Generic;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.Calculators.Infrastructure.Calculators.Binary;
using RuleEngine.Calculators.Infrastructure.Calculators.Unary;
using System;

namespace RuleEngine.Calculators
{
    public enum RuleEnum
    {
        ThreeCalculatorRule,
        BenchMark,
        HeldInstrumentCount,
        HeldIssuerCount,
        PortfolioHoldingValue,
        InstrumentBenchmark
    }

    public class RuleCalculatorFactory
    {
        public ICalculator CreateRuleCalculator(RuleEnum rule, ICalculatorVisitor calculatorVisitor)
        {
            ICalculator calculator = null;

            switch (rule)
            {
                case RuleEnum.BenchMark:
                    calculator = new BenchMarkCalculator();
                    break;

                case RuleEnum.ThreeCalculatorRule:
                    calculator = new AdditionCalculator(new SingleValueCalculator(2), new SingleValueCalculator(5));
                    break;

                case RuleEnum.HeldInstrumentCount:
                    calculator = new HeldInstrumentCountCalculator();
                    break;

                case RuleEnum.HeldIssuerCount:
                    calculator = new HeldIssuerCountCalculator();
                    break;

                case RuleEnum.PortfolioHoldingValue:
                    calculator = new PortfolioHoldingCalculator();
                    break;

                case RuleEnum.InstrumentBenchmark:
                    calculator = new BenchMarkCalculator();
                    break;
            }

            if (calculator != null)
                calculator.Accept(calculatorVisitor);

            return calculator;
        }
    }
}
