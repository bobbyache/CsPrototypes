using System;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Linq;
using System.Collections;
using Rdl2RdlcConverter;

namespace RDLtoRDLCConverter_Tests
{
    [TestClass]
    [DeploymentItem(@"ReportFiles\rptBreachHistory.rdl")]
    public class Tests
    {
        [TestInitialize]
        public void Initialize()
        {
            //if (File.Exists("rptBreachHistory.rdlc"))
            //    File.Delete("rptBreachHistory.rdlc");
        }

        [TestCleanup]
        public void TearDown()
        {
            //if (File.Exists("rptBreachHistory.rdlc"))
            //    File.Delete("rptBreachHistory.rdlc");
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
            Assert.AreEqual("dsRef", elements[0].Element("DataSourceName").Value);
            Assert.AreEqual("/* Local Query */", elements[0].Element("CommandText").Value);
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
