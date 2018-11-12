using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngine.Calculators;
using RuleEngine.Calculators.Data;
using System.Collections.Generic;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.UnitTests.PortfolioHolding.Stubs;
using RuleEngine.Calculators.Custom;

namespace RuleEngine.UnitTests.PortfolioHolding
{
    [TestClass]
    public class HeldIssuerCountCalculatorTests
    {
        [TestMethod]
        public void HeldIssuerCountCalculator_Calculate_Returns_ExpectedResult()
        {
            ICalculator calculator = new HeldIssuerCountCalculator("");
            calculator.Accept(new StubCalculatorVisitor());
            decimal val = calculator.Calculate();

            Assert.AreEqual(3, val);
        }
    }
}
