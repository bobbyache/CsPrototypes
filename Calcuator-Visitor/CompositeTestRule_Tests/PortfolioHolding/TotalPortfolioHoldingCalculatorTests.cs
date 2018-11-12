using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RuleEngine.Calculators;
using RuleEngine.Calculators.Data;
using RuleEngine.Calculators.Infrastructure.Data;
using RuleEngine.Calculators.Custom;

namespace RuleEngine.UnitTests.PortfolioHolding
{
    [TestClass]
    public class TotalPortfolioHoldingCalculatorTests
    {
        [TestMethod]
        public void TotalPortfolioHoldingCalculator_Calculate_WithTwoMatchingPortfolios_ReturnsExpectedResult()
        {
            IEnumerable<PortfolioInstrumentDecimalDataItem> sourceData = new List<PortfolioInstrumentDecimalDataItem>
            {
                new PortfolioInstrumentDecimalDataItem(367, 92164, 1586943.6200M),
                new PortfolioInstrumentDecimalDataItem(368, 89258, 342679.9500M),
                new PortfolioInstrumentDecimalDataItem(368, 89260, 106743.0000M)
            };

            IEnumerable<IdDataItem> portfolioDataList = new List<IdDataItem>
            {
                new IdDataItem(368)
            };

            IEnumerable<IdAndBooleanValueDataItem> instrumentDataList = new List<IdAndBooleanValueDataItem>
            {
                new IdAndBooleanValueDataItem(90658, false)
            };

            TotalPortfolioHoldingCalculator calculator = new TotalPortfolioHoldingCalculator();
            calculator.SourceData = sourceData;
            calculator.PortfolioDataList = portfolioDataList;
            calculator.InstrumentDataList = instrumentDataList;
            decimal val = calculator.Calculate();

            Assert.AreEqual(449422.95M, val);

        }
    }
}
