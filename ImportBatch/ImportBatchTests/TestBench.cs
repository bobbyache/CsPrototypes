using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImportBatch;
using System.Collections.Generic;
using System.Linq;

namespace ImportBatchTests
{
    [TestClass]
    [DeploymentItem(@"Files\ImportConfig.xml")]
    public class TestBench
    {
        [TestMethod]
        public void ConfigParser_WhenInitialized_Sets_FilePath()
        {
            ConfigParser parser = new ConfigParser("ImportConfig.xml");
            Assert.AreEqual(parser.FilePath, "ImportConfig.xml");
        }

        [TestMethod]
        public void ConfigParser_WhenInitialized_Lists_Tables_Correctly()
        {
            ConfigParser parser = new ConfigParser("ImportConfig.xml");
            parser.Parse();

            Assert.AreEqual("RatingScale", parser.TableNames[0]);
            Assert.AreEqual(27, parser.TableNames.Length);
            Assert.AreEqual("PortfolioHoldingIntraDay", parser.TableNames[26]);
        }

        [TestMethod]
        public void ConfigParser_WhenInitialized_Lists_Attributes_Correctly()
        {
            ConfigParser parser = new ConfigParser("ImportConfig.xml");
            parser.Parse();

            Assert.AreEqual("Rule", parser.Attributes[0]);
            Assert.AreEqual(21, parser.Attributes.Length);
            Assert.AreEqual("PortfolioIssuer", parser.Attributes[20]);
        }

        [TestMethod]
        public void ConfigParser_WhenInitialized_Lists_Classifications_Correctly()
        {
            ConfigParser parser = new ConfigParser("ImportConfig.xml");
            parser.Parse();

            Assert.AreEqual("INS", parser.Classifications[0]);
            Assert.AreEqual(3, parser.Classifications.Length);
            Assert.AreEqual("RULE", parser.Classifications[1]);
        }

        [TestMethod]
        public void ConfigParser_GetTables_GetsTables_Correctly()
        {
            ConfigParser parser = new ConfigParser("ImportConfig.xml");
            parser.Parse();
            IMappableTable[] tables = parser.GetMappableTables();

            Assert.AreEqual(27, tables.Length);
        }

        [TestMethod]
        public void ConfigParser_GetTables_Get_First_Table_Has_Correct_Values()
        {
            ConfigParser parser = new ConfigParser("ImportConfig.xml");
            parser.Parse();
            IMappableTable table = parser.GetMappableTables().ElementAt(1);

            Assert.AreEqual("Issuer", table.TableName);
            Assert.AreEqual("vw_compliance_export_Issuer", table.SourceViewName);
            Assert.AreEqual(true, table.Enabled);
            Assert.AreEqual(false, table.BulkCopy);
        }
    }
}
