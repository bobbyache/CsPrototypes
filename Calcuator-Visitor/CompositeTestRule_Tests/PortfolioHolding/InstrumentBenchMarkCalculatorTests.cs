using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngine.Calculators.Data;
using System.Collections.Generic;
using RuleEngine.Calculators;
using RuleEngine.Calculators.Infrastructure.Data;
using RuleEngine.Calculators.Custom;

namespace RuleEngine.UnitTests.PortfolioHolding
{
    [TestClass]
    public class InstrumentBenchmarkCalculatorTests
    {
        [TestMethod]
        public void InstrumentInBenchMarkCalculator_Calculate_Returns_ExpectedResult()
        {
            IEnumerable<IdAndBooleanValueDataItem> contextualInstruments = new List<IdAndBooleanValueDataItem>
            {
                new IdAndBooleanValueDataItem(368, false),
                new IdAndBooleanValueDataItem(424, false)
            };

            IEnumerable<IdAndBooleanValueDataItem> componentInstruments = new List<IdAndBooleanValueDataItem>
            {
                new IdAndBooleanValueDataItem(368, false),
                new IdAndBooleanValueDataItem(424, false)
            };

            InstrumentInBenchmarkCalculator calculator = new InstrumentInBenchmarkCalculator();
            calculator.ContextualInstruments = contextualInstruments;
            calculator.ComponentInstruments = componentInstruments;

            decimal val = calculator.Calculate();

            Assert.AreEqual(2, val);
        }
    }
}
