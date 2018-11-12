using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngine.Data.Repositories;
using System.Data;

namespace RuleEngine.IntegrationTests
{
    [TestClass]
    public class IssuerRepositoryTests
    {
        [TestMethod]
        [TestCategory("Repositories")]
        public void IssuerRepository_GetInstrumentAggregates_Returns_Data()
        {
            ContextRepository contextRepository = new ContextRepository(Constants.ConnectionString);
            string commaDelimitedInstrumentIds = contextRepository.GetContextualInstrumentCommaDelimitedIds();

            IssuerRepository issuerRepository = new IssuerRepository(Constants.ConnectionString);
            DataTable dataTable = issuerRepository.GetAggregates(commaDelimitedInstrumentIds);

            Assert.IsTrue(dataTable.Rows.Count > 0);
        }
    }
}
