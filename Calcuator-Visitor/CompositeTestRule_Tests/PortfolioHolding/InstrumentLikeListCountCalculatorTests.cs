using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngine.Calculators;
using RuleEngine.Calculators.Custom;
using RuleEngine.Calculators.Data;
using RuleEngine.Calculators.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.UnitTests.PortfolioHolding
{
    [TestClass]
    public class InstrumentLikeListCountCalculatorTests
    {
        [TestMethod]
        public void InstrumentLikeListCountCalculator_Calculate_Returns_ExpectedResult()
        {
            IEnumerable<IdAndBooleanValueDataItem> instrumentLikeDataList = new List<IdAndBooleanValueDataItem>()
            {
                new IdAndBooleanValueDataItem(368, false),
                new IdAndBooleanValueDataItem(379, false)
            };

            IEnumerable<IdAndBooleanValueDataItem> instrumentDataList = new List<IdAndBooleanValueDataItem>()
            {
                new IdAndBooleanValueDataItem(368, false),
                new IdAndBooleanValueDataItem(369, false),
                new IdAndBooleanValueDataItem(379, false)
            };

            InstrumentLikeListCountCalculator calculator = new InstrumentLikeListCountCalculator();
            calculator.InstrumentData = instrumentDataList;
            calculator.LikeInstrumentData = instrumentLikeDataList;
            decimal val = calculator.Calculate();

            Assert.AreEqual(2, val);
        }
    }
}
