using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngine.Data.Repositories;
using System.Data;

namespace RuleEngine.IntegrationTests
{
    [TestClass]
    public class ContextRepositoryTests
    {
        [TestMethod]
        [TestCategory("Repositories")]
        public void ContextRepository_GetContextualInstruments_Returns_DataSet_Of_Instruments()
        {
            ContextRepository contextRepository = new ContextRepository(Constants.ConnectionString);
            DataTable dataTable = contextRepository.GetContextualInstruments();
            Assert.IsTrue(dataTable.Rows.Count == 40);
        }

        [TestMethod]
        [TestCategory("Repositories")]
        public void ContextRepository_GetContextualInstruments_Returns_CommaDelimited_InstrumentIds()
        {
            ContextRepository contextRepository = new ContextRepository(Constants.ConnectionString);
            string commaDelimitedIds = contextRepository.GetContextualInstrumentCommaDelimitedIds();
            Assert.IsFalse(string.IsNullOrEmpty(commaDelimitedIds));
        }
    }
}
