using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngine.Calculators.Calculators.Custom;
using RuleEngine.Calculators.Infrastructure.Calculators.Custom;
using System.Collections.Generic;
using RuleEngine.Data;

namespace RuleEngine.UnitTests.PortfolioHolding
{
    [TestClass]
    public class PortfolioAttributeValueCalculatorTests
    {
        [TestMethod]
        [TestCategory("Context")]
        public void PortfolioAttributeValueCalculator_SetContext_Intersects_ContextualData()
        {
            IPortfolioAttributeValueCalculator calculator = new PortfolioAttributeValueCalculator("");
            int[] allowedInstruments = new int[] { 345, 346 };
            IEnumerable<Tuple<int, int>> instrumentPools = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(2, 345),
                new Tuple<int, int>(3, 346),
                new Tuple<int, int>(4, 445),

            };

            calculator.SetContext(instrumentPools, allowedInstruments);

            Assert.AreEqual(2, calculator.InstrumentPools.Length);
        }

        [TestMethod]
        [TestCategory("Context")]
        public void PortfolioAttributeValueCalculator_SetContext_FromVisitor_Intersects_ContextualData()
        {
            CalculatorVisitor calculatorVisitor = new CalculatorVisitor("connect_string");
            IPortfolioAttributeValueCalculator calculator = new PortfolioAttributeValueCalculator("");

            calculator.Accept(calculatorVisitor);
            calculator.Calculate();


            Assert.AreEqual(3, calculator.InstrumentPools.Length);
            Assert.AreEqual(1000, calculator.Answers[0].Item3);
            Assert.AreEqual(500, calculator.Answers[1].Item3);
        }
    }
}
