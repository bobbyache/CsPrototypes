using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngine.Calculators;
using RuleEngine.Calculators.Binary;
using RuleEngine.Calculators.Calculators.Base;
using RuleEngine.Calculators.Calculators.Unary;
using RuleEngine.Calculators.Custom;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.Calculators.Infrastructure.Calculators.Custom;
using RuleEngine.Data;
using RuleEngine.UnitTests.PortfolioHolding.Stubs;

namespace RuleEngine.UnitTests.PortfolioHolding
{
    [TestClass]
    public class VisitorTests
    {
        [TestMethod]
        public void RuleCalculatorFactory_CreateCalculator_AdditionCalculator_Returns_CorrectValue()
        {
            BaseCalculator calculator = new AdditionCalculator("");
            calculator.AddCalculator(new SingleValueCalculator("", 2));
            calculator.AddCalculator(new SingleValueCalculator("", 5));

            calculator.Accept(new StubCalculatorVisitor());
            decimal value = calculator.Calculate();

            Assert.AreEqual(7, value);
        }

        [TestMethod]
        public void RuleCalculatorFactory_CreateCalculator_BenchMark_Returns_IBenchMarkCalculator()
        {
            ICalculator calculator = new BenchMarkCalculator("");
            decimal value = calculator.Calculate();

            Assert.IsInstanceOfType(calculator, typeof(IBenchMarkCalculator));
        }
    }
}
