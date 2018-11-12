using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngine.Calculators.Calculators.Logical;
using RuleEngine.Calculators.Infrastructure;

namespace RuleEngine.UnitTests.PortfolioHolding
{
    [TestClass]
    public class LogicalCalculatorTests
    {
        [TestMethod]
        public void EqualCalculator_Calculate_ReturnsExpected_True_Result()
        {
            StubCalculator leftCalculator = new StubCalculator(2);
            StubCalculator rightCalculator = new StubCalculator(2);

            EqualCalculator calculator = new EqualCalculator(leftCalculator, rightCalculator);
            decimal result = calculator.Calculate();

            Assert.AreEqual(1, result);
        }


        [TestMethod]
        public void GreaterThanCalculator_Calculate_ReturnsExpected_True_Result()
        {
            StubCalculator leftCalculator = new StubCalculator(2);
            StubCalculator rightCalculator = new StubCalculator(1);

            GreaterThanCalculator calculator = new GreaterThanCalculator(leftCalculator, rightCalculator);
            decimal result = calculator.Calculate();

            Assert.AreEqual(1, result);
        }


        [TestMethod]
        public void GreaterThanOrEqualCalculator_Calculate_ReturnsExpected_True_Result()
        {
            StubCalculator leftCalculator = new StubCalculator(2);
            StubCalculator rightCalculator = new StubCalculator(1);

            GreaterThanOrEqualCalculator calculator = new GreaterThanOrEqualCalculator(leftCalculator, rightCalculator);
            decimal result = calculator.Calculate();

            Assert.AreEqual(1, result);
        }


        [TestMethod]
        public void LessThanCalculator_Calculate_ReturnsExpected_True_Result()
        {
            StubCalculator leftCalculator = new StubCalculator(1);
            StubCalculator rightCalculator = new StubCalculator(2);

            LessThanCalculator calculator = new LessThanCalculator(leftCalculator, rightCalculator);
            decimal result = calculator.Calculate();

            Assert.AreEqual(1, result);
        }


        [TestMethod]
        public void LessThanOrEqualCalculator_Calculate_ReturnsExpected_True_Result()
        {
            StubCalculator leftCalculator = new StubCalculator(1);
            StubCalculator rightCalculator = new StubCalculator(2);

            LessThanOrEqualCalculator calculator = new LessThanOrEqualCalculator(leftCalculator, rightCalculator);
            decimal result = calculator.Calculate();

            Assert.AreEqual(1, result);
        }


        [TestMethod]
        public void NotEqualCalculator_Calculate_ReturnsExpected_True_Result()
        {
            StubCalculator leftCalculator = new StubCalculator(1);
            StubCalculator rightCalculator = new StubCalculator(2);

            NotEqualCalculator calculator = new NotEqualCalculator(leftCalculator, rightCalculator);
            decimal result = calculator.Calculate();

            Assert.AreEqual(1, result);
        }


        [TestMethod]
        public void EqualCalculator_Calculate_ReturnsExpected_False_Result()
        {
            StubCalculator leftCalculator = new StubCalculator(3);
            StubCalculator rightCalculator = new StubCalculator(2);

            EqualCalculator calculator = new EqualCalculator(leftCalculator, rightCalculator);
            decimal result = calculator.Calculate();

            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void GreaterThanCalculator_Calculate_ReturnsExpected_False_Result()
        {
            StubCalculator leftCalculator = new StubCalculator(1);
            StubCalculator rightCalculator = new StubCalculator(2);

            GreaterThanCalculator calculator = new GreaterThanCalculator(leftCalculator, rightCalculator);
            decimal result = calculator.Calculate();

            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void GreaterThanOrEqualCalculator_Calculate_ReturnsExpected_False_Result()
        {
            StubCalculator leftCalculator = new StubCalculator(1);
            StubCalculator rightCalculator = new StubCalculator(2);

            GreaterThanOrEqualCalculator calculator = new GreaterThanOrEqualCalculator(leftCalculator, rightCalculator);
            decimal result = calculator.Calculate();

            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void LessThanCalculator_Calculate_ReturnsExpected_False_Result()
        {
            StubCalculator leftCalculator = new StubCalculator(3);
            StubCalculator rightCalculator = new StubCalculator(2);

            LessThanCalculator calculator = new LessThanCalculator(leftCalculator, rightCalculator);
            decimal result = calculator.Calculate();

            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void LessThanOrEqualCalculator_Calculate_ReturnsExpected_False_Result()
        {
            StubCalculator leftCalculator = new StubCalculator(3);
            StubCalculator rightCalculator = new StubCalculator(2);

            LessThanOrEqualCalculator calculator = new LessThanOrEqualCalculator(leftCalculator, rightCalculator);
            decimal result = calculator.Calculate();

            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void NotEqualCalculator_Calculate_ReturnsExpected_False_Result()
        {
            StubCalculator leftCalculator = new StubCalculator(3);
            StubCalculator rightCalculator = new StubCalculator(3);

            NotEqualCalculator calculator = new NotEqualCalculator(leftCalculator, rightCalculator);
            decimal result = calculator.Calculate();

            Assert.AreEqual(0, result);
        }



        private class StubCalculator : ICalculator
        {
            private decimal returnValue;

            public string ShortName { get { return ""; } }

            public int RuleId
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public string AggregateName
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public StubCalculator(decimal returnValue)
            {
                this.returnValue = returnValue;
            }

            public void Accept(ICalculatorVisitor visitor)
            {
                throw new NotImplementedException();
            }

            public decimal Calculate()
            {
                return returnValue;
            }
        }

    }
}
