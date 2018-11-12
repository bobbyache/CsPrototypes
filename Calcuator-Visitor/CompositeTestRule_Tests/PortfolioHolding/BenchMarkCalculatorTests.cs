using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.UnitTests.PortfolioHolding.Stubs;
using RuleEngine.Calculators.Custom;

namespace RuleEngine.UnitTests.PortfolioHolding
{
    [TestClass]
    public class BenchMarkCalculatorTests
    {
        [TestMethod]
        public void BenchMarkCalculator_Calculate_WithInstrumentData_Returns_ExpectedResult()
        {
            ICalculatorVisitor visitor = new StubCalculatorVisitor();

            BenchMarkCalculator calculator = new BenchMarkCalculator("");
            calculator.Accept(visitor);
            decimal val = calculator.Calculate();

            Assert.AreEqual(10M, val);
        }

        [TestMethod]
        public void BenchMarkCalculator_Calculate_WithIssuerData_Returns_ExpectedResult()
        {
            ICalculatorVisitor visitor = new StubCalculatorVisitor();

            BenchMarkCalculator calculator = new BenchMarkCalculator("");
            calculator.Accept(visitor);
            decimal val = calculator.Calculate();

            Assert.AreEqual(10M, val);
        }
    }
}
