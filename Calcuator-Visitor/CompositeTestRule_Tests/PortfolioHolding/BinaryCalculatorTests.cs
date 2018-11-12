using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngine.Calculators.Binary;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.Calculators.Calculators.Base;

namespace RuleEngine.UnitTests.PortfolioHolding
{
    [TestClass]
    public class BinaryCalculatorTests
    {
        [TestMethod]
        public void DivisionCalculator_Calculate_ReturnsExpectedResult()
        {
            StubCalculator numeratorCalculator = new StubCalculator(2, "");
            StubCalculator denominatorCalculator = new StubCalculator(10, "");

            DivisionCalculator calculator = new DivisionCalculator(numeratorCalculator, denominatorCalculator);
            decimal result = calculator.Calculate();

            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void DivisionCalculator_Calculate_WithZeroDenominator_ReturnsExpectedResult()
        {
            StubCalculator numeratorCalculator = new StubCalculator(2, "");
            StubCalculator denominatorCalculator = new StubCalculator(0, "");

            DivisionCalculator calculator = new DivisionCalculator(numeratorCalculator, denominatorCalculator);
            decimal result = calculator.Calculate();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SubtractionCalculator_Calculate_ReturnsExpectedResult()
        {
            StubCalculator calculator1 = new StubCalculator(2, "");
            StubCalculator calculator2 = new StubCalculator(10, "");

            SubtractionCalculator calculator = new SubtractionCalculator(calculator1, calculator2);
            decimal result = calculator.Calculate();

            Assert.AreEqual(-8, result);
        }

        [TestMethod]
        public void AdditionCalculator_Calculate_ReturnsExpectedResult()
        {
            StubCalculator calculator1 = new StubCalculator(2, "");
            StubCalculator calculator2 = new StubCalculator(10, "");

            AdditionCalculator calculator = new AdditionCalculator("");
            calculator.AddCalculator(calculator1);
            calculator.AddCalculator(calculator2);
            decimal result = calculator.Calculate();

            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void MultiplicationCalculator_Calculate_ReturnsExpectedResult()
        {
            StubCalculator calculator1 = new StubCalculator(2, "");
            StubCalculator calculator2 = new StubCalculator(10, "");

            MultiplicationCalculator calculator = new MultiplicationCalculator(calculator1, calculator2);
            decimal result = calculator.Calculate();

            Assert.AreEqual(20, result);
        }

        private class StubCalculator : BaseCalculator
        {
            public StubCalculator(decimal returnValue, string shortName) : base(shortName)
            {
                this.returnValue = returnValue;
            }

            public override decimal Calculate()
            {
                return returnValue;
            }

            private decimal returnValue;
        }
    }
}
