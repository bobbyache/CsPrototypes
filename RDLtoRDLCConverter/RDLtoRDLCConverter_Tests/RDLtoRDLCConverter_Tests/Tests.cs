using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rdl2RdlcConverter;
using System.IO;
using System.Xml.Linq;

namespace RDLtoRDLCConverter_Tests
{
    [TestClass]
    [DeploymentItem(@"ReportFiles\rptBreachHistory.rdl")]
    public class Tests
    {
        private XNamespace xmlns = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/reportdefinition";
        private XNamespace xmlns_rd = "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner";

        [TestInitialize]
        public void Initialize()
        {
            if (File.Exists("rptBreachHistory.rdlc"))
                File.Delete("rptBreachHistory.rdlc");
        }

        [TestCleanup]
        public void TearDown()
        {
            if (File.Exists("rptBreachHistory.rdlc"))
                File.Delete("rptBreachHistory.rdlc");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRdlFileException))]
        public void RdlcConverter_Convert_Fails_If_Passed_A_Non_RDL_Extension()
        {
            RdlcConverter creator = new RdlcConverter();
            creator.Convert("rptBreachHistory.rdlc");
        }

        [TestMethod]
        public void Test_TestFile_Is_Deployed()
        {
            string filePath = "rptBreachHistory.rdl";

            string text = File.ReadAllText(filePath);

            Assert.IsFalse(string.IsNullOrEmpty(text));
        }

        [TestMethod]
        public void RdlcConverter_Convert_Creates_New_RDLC_File_At_Same_Path()
        {
            RdlcConverter creator = new RdlcConverter();
            creator.Convert("rptBreachHistory.rdl");

            bool fileExists = File.Exists("rptBreachHistory.rdlc");
            
            Assert.IsTrue(fileExists);
        }

        [TestMethod]
        public void RdlcConverter_GetDataSetElements_Finds_First_DataSet_Element()
        {
            RdlcConverter creator = new RdlcConverter();
            XDocument document = XDocument.Load("rptBreachHistory.rdl");

            var elements = creator.GetDataSetElements(document);
            Assert.AreEqual("DataSet1", elements[0].FirstAttribute.Value);
        }

        [TestMethod]
        public void RdlcConverter_Convert_Replaces_Query_Element_But_Keeps_Current_DataSet_Attributes()
        {
            RdlcConverter creator = new RdlcConverter();
            creator.Convert("rptBreachHistory.rdl");

            XDocument document = XDocument.Load("rptBreachHistory.rdlc");
            var elements = creator.GetDataSetElements(document);

            Assert.AreEqual("DataSet1", elements[0].FirstAttribute.Value);

            Assert.IsNotNull(elements[0].Element(xmlns + "Query").Element(xmlns + "DataSourceName"));
            Assert.IsNotNull(elements[0].Element(xmlns + "Query").Element(xmlns + "CommandText"));
            Assert.IsNotNull(elements[0].Element(xmlns + "Query").Element(xmlns + "QueryParameters"));


            Assert.AreEqual("dsRef", elements[0].Element(xmlns + "Query").Element(xmlns + "DataSourceName").Value);
            Assert.AreEqual("/* Local Query */", elements[0].Element(xmlns + "Query").Element(xmlns + "CommandText").Value);

            //Assert.AreEqual("dsRef", elements[0].Element(xmlns + "DataSourceName").Value);
            //Assert.AreEqual("/* Local Query */", elements[0].Element(xmlns + "CommandText").Value);

            Assert.IsNotNull(elements[0].Element(xmlns + "Fields"));
        }

        [TestMethod]
        public void RdlcConverter_GetDataSourceElements_Finds_First_DataSet_Element()
        {
            RdlcConverter creator = new RdlcConverter();
            XDocument document = XDocument.Load("rptBreachHistory.rdl");

            var elements = creator.GetDataSourceElements(document);
            Assert.AreEqual("dsRef", elements[0].FirstAttribute.Value);
        }

        [TestMethod]
        public void RdlcConverter_GetDataSourceId_Using_Name_IsSuccessful()
        {
            RdlcConverter creator = new RdlcConverter();
            XDocument document = XDocument.Load("rptBreachHistory.rdl");

            var id = creator.GetDataSourceId(document, "dsRef");
            Assert.AreEqual("7a2a0f8f-bfc8-4555-a48e-2f1b3315832c", id);
        }
    }
}
