using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using ModuleXmlReader;

namespace ModuleXmlReaderTests
{
    [TestClass]
    [DeploymentItem(@"Modules\ReportsModule.xml")]
    public class UnitTest1
    {
        public string XDocument { get; private set; }
        

        [TestMethod]
        public void ReadsXmlFileSuccessfully()
        {
            string xml = System.Xml.Linq.XDocument.Load("ReportsModule.xml").ToString();
        }

        [TestMethod]
        public void GetTopLevelMenus()
        {
            ModuleMenuReader menuSystem = new ModuleMenuReader("ReportsModule.xml");
            Assert.IsInstanceOfType(menuSystem.RootMenu, typeof(ModuleMenu));
            Assert.AreEqual("&Reports", menuSystem.RootMenu.Text);
        }

        [TestMethod]
        public void GetAllMenus()
        {
            ModuleMenuReader menuSystem = new ModuleMenuReader("ReportsModule.xml");
            Assert.IsTrue(menuSystem.RootMenu.Menus.Length > 0);
        }

        [TestMethod]
        public void GetNameOfModule()
        {
            ModuleMenuReader menuSystem = new ModuleMenuReader("ReportsModule.xml");
            Assert.AreEqual("ReportsModule", menuSystem.Name);
        }

        [TestMethod]
        public void GetDescriptionOfModule()
        {
            ModuleMenuReader menuSystem = new ModuleMenuReader("ReportsModule.xml");
            Assert.AreEqual("Reports Module", menuSystem.Description);
        }
    }
}
