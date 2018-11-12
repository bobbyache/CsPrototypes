using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RuleEngine.Calculators;
using RuleEngine.Calculators.Infrastructure.Data;
using RuleEngine.Calculators.Infrastructure.Calculators.Custom;
using RuleEngine.Calculators.Calculators.Custom;
using RuleEngine.UnitTests.PortfolioHolding.Stubs;

namespace RuleEngine.UnitTests.PortfolioHolding
{
    [TestClass]
    public class CompositeTestCalculatorTests
    {
        [TestMethod]
        public void PortfolioHoldingValueCalculator_Calculate_WithSingleMatchingData_Returns_ExpectedResult()
        {
            IEnumerable<PortfolioInstrumentDecimalDataItem> sourceData = new List<PortfolioInstrumentDecimalDataItem>
            {
                new PortfolioInstrumentDecimalDataItem(368, 24, 27845285.2400M),
                new PortfolioInstrumentDecimalDataItem(424, 61, 2371390.2000M),
                new PortfolioInstrumentDecimalDataItem(324, 47, -720.4500M)
            };

            IEnumerable<IdDataItem> portfolioDataList = new List<IdDataItem>() { new IdDataItem(368) };
            IEnumerable<IdAndBooleanValueDataItem> instrumentDataList = new List<IdAndBooleanValueDataItem>() { new IdAndBooleanValueDataItem(24, false) };

            IPortfolioHoldingCalculator calculator = new PortfolioHoldingCalculator("");
            calculator.InstrumentDataList = instrumentDataList;
            calculator.PortfolioDataList = portfolioDataList;
            calculator.SourceData = sourceData;

            decimal val = calculator.Calculate();

            Assert.AreEqual(27845285.2400M, val);
        }

        [TestMethod]
        public void PortfolioHoldingValueCalculator_Calculate_WithNoMatchingData_Returns_ExpectedResult()
        {
            IEnumerable<PortfolioInstrumentDecimalDataItem> sourceData = new List<PortfolioInstrumentDecimalDataItem>
            {
                new PortfolioInstrumentDecimalDataItem(368, 35, 27845285.2400M),
                new PortfolioInstrumentDecimalDataItem(424, 61, 2371390.2000M),
                new PortfolioInstrumentDecimalDataItem(324, 47, -720.4500M)
            };

            IEnumerable<IdDataItem> portfolioDataList = new List<IdDataItem>() { new IdDataItem(368) };
            IEnumerable<IdAndBooleanValueDataItem> instrumentDataList = new List<IdAndBooleanValueDataItem>() { new IdAndBooleanValueDataItem(24, false) };

            IPortfolioHoldingCalculator calculator = new PortfolioHoldingCalculator("");
            calculator.InstrumentDataList = instrumentDataList;
            calculator.PortfolioDataList = portfolioDataList;
            calculator.SourceData = sourceData;

            decimal val = calculator.Calculate();

            Assert.AreEqual(0M, val);
        }

        [TestMethod]
        public void PortfolioHoldingValueCalculator_Calculate_WithTwoPortfoliosInContext_Returns_ExpectedResult()
        {
            IEnumerable<PortfolioInstrumentDecimalDataItem> sourceData = new List<PortfolioInstrumentDecimalDataItem>
            {
                new PortfolioInstrumentDecimalDataItem(368, 24, 27845285.2400M),
                new PortfolioInstrumentDecimalDataItem(507, 28, 48235190.8900M),
                new PortfolioInstrumentDecimalDataItem(324, 37, -720.4500M)
            };

            IEnumerable<IdDataItem> portfolioDataList = new List<IdDataItem>()
            {
                new IdDataItem(368),
                new IdDataItem(507)
            };

            IEnumerable<IdAndBooleanValueDataItem> instrumentDataList = new List<IdAndBooleanValueDataItem>()
            {
                new IdAndBooleanValueDataItem(24, false),
                new IdAndBooleanValueDataItem(28, false)
            };

            IPortfolioHoldingCalculator calculator = new PortfolioHoldingCalculator("");

            calculator.InstrumentDataList = instrumentDataList;
            calculator.PortfolioDataList = portfolioDataList;
            calculator.SourceData = sourceData;

            decimal val = calculator.Calculate();

            Assert.AreEqual(76080476.13M, val);
        }

        [TestMethod]
        public void PortfolioHoldingValueCalculator_Calculate_WithNegativeValue_Returns_ExpectedResult()
        {
            IEnumerable<PortfolioInstrumentDecimalDataItem> sourceData = new List<PortfolioInstrumentDecimalDataItem>
            {
                new PortfolioInstrumentDecimalDataItem(368, 24, 27845285.2400M),
                new PortfolioInstrumentDecimalDataItem(507, 28, 48235190.8900M),
                new PortfolioInstrumentDecimalDataItem(324, 37, -720.4500M)
            };

            IEnumerable<IdDataItem> portfolioDataList = new List<IdDataItem>()
            {
                new IdDataItem(368),
                new IdDataItem(324)
            };

            IEnumerable<IdAndBooleanValueDataItem> instrumentDataList = new List<IdAndBooleanValueDataItem>()
            {
                new IdAndBooleanValueDataItem(24, false),
                new IdAndBooleanValueDataItem(37, false)
            };

            IPortfolioHoldingCalculator calculator = new PortfolioHoldingCalculator("");
            calculator.InstrumentDataList = instrumentDataList;
            calculator.PortfolioDataList = portfolioDataList;
            calculator.SourceData = sourceData;

            decimal val = calculator.Calculate();

            Assert.AreEqual(27844564.79M, val);
        }

        [TestMethod]
        public void PortfolioHoldingValueCalculator_Calculate_WithNegativeValue_AsAbsolute_Returns_ExpectedResult()
        {
            IEnumerable<PortfolioInstrumentDecimalDataItem> sourceData = new List<PortfolioInstrumentDecimalDataItem>
            {
                new PortfolioInstrumentDecimalDataItem(368, 24, 27845285.2400M),
                new PortfolioInstrumentDecimalDataItem(507, 28, 48235190.8900M),
                new PortfolioInstrumentDecimalDataItem(324, 37, -720.4500M)
            };

            IEnumerable<IdDataItem> portfolioDataList = new List<IdDataItem>()
            {
                new IdDataItem(368),
                new IdDataItem(324)
            };

            IEnumerable<IdAndBooleanValueDataItem> instrumentDataList = new List<IdAndBooleanValueDataItem>()
            {
                new IdAndBooleanValueDataItem(24, false),
                new IdAndBooleanValueDataItem(37, false)
            };

            IPortfolioHoldingCalculator calculator = new PortfolioHoldingCalculator("");

            calculator.InstrumentDataList = instrumentDataList;
            calculator.PortfolioDataList = portfolioDataList;
            calculator.SourceData = sourceData;
            calculator.Abs = true;

            decimal val = calculator.Calculate();

            Assert.AreEqual(27846005.69M, val);
        }

        [TestMethod]
        public void PortfolioHoldingValueCalculator_Calculate_UseUnderlying_Returns_ExpectedResult()
        {
            IEnumerable<PortfolioInstrumentDecimalDataItem> sourceData = new List<PortfolioInstrumentDecimalDataItem>
            {
                new PortfolioInstrumentDecimalDataItem(368, 24, 27845285.2400M),
                new PortfolioInstrumentDecimalDataItem(507, 28, 48235190.8900M)
            };

            IEnumerable<IdDataItem> portfolioDataList = new List<IdDataItem>()
            {
                new IdDataItem(368),
                new IdDataItem(507)
            };

            IEnumerable<IdAndBooleanValueDataItem> instrumentDataList = new List<IdAndBooleanValueDataItem>()
            {
                new IdAndBooleanValueDataItem(24, true),
                new IdAndBooleanValueDataItem(28, false)
            };

            IPortfolioHoldingCalculator calculator = new PortfolioHoldingCalculator("");
            calculator.Accept(new StubCalculatorVisitor());

            calculator.InstrumentDataList = instrumentDataList;
            calculator.PortfolioDataList = portfolioDataList;
            calculator.SourceData = sourceData;
            calculator.UseUnderlyingInstrument = true;

            decimal val = calculator.Calculate();

            Assert.AreEqual(27845285.2400M, val);
        }
    }
}
