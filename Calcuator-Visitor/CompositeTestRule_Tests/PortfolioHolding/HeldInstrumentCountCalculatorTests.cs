using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngine.Calculators.Data;
using System.Collections.Generic;
using RuleEngine.Calculators;
using RuleEngine.Calculators.Infrastructure.Data;
using RuleEngine.UnitTests.PortfolioHolding.Stubs;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.Calculators.Custom;

namespace RuleEngine.UnitTests.PortfolioHolding
{
    [TestClass]
    public class HeldInstrumentCountCalculatorTests
    {
        [TestMethod]
        public void HeldInstrumentCountCalculator_Calculate_Returns_ExpectedResult()
        {
            RuleCalculatorFactory factory = new RuleCalculatorFactory();
            ICalculator calculator = new HeldInstrumentCountCalculator("");
            calculator.Accept(new StubCalculatorVisitor());
            decimal val = calculator.Calculate();

            Assert.AreEqual(1, val);
        }
    }
}
