using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using ModuleXmlReader;
using System.Text;

namespace ModuleXmlReaderTests
{
    [TestClass]
    [DeploymentItem(@"Modules\ReportsModule.xml")]
    [DeploymentItem(@"Modules\MaintenanceModule.xml")]
    [DeploymentItem(@"Modules\TestModule.xml")]
    public class UnitTest1
    {
        public string XDocument { get; private set; }

        [TestMethod]
        public void RipModule_2()
        {
            ModuleMenuReader menuSystem = new ModuleMenuReader("TestModule.xml");

            foreach (var item in menuSystem.RootMenu.Menus)
            {
                if (item.Menus.Length > 0)
                {
                    foreach (var subItem in item.Menus)
                    {
                        if (subItem.CommandItem != null)
                            System.Diagnostics.Debug.WriteLine($"{subItem.Command} \t {subItem.CommandItem.Execute} \t {subItem.CommandItem.DisplayName}");
                    }
                }
                else
                {
                    if (item.CommandItem != null)
                        System.Diagnostics.Debug.WriteLine($"{item.Command} \t {item.CommandItem.Execute} \t {item.CommandItem.DisplayName}");

                }
            }

            Assert.IsTrue(menuSystem.RootMenu != null);
        }

        [TestMethod]
        public void RipModule()
        {
            string section = "Section";
            string subsection = "SubSection";
            ModuleMenuReader menuSystem = new ModuleMenuReader("TestModule.xml");

            foreach (var item in menuSystem.RootMenu.Menus)
            {
                if (item.Menus.Length > 0)
                {
                    foreach (var subItem in item.Menus)
                    {
                        System.Diagnostics.Debug.WriteLine($"{section},{subsection},{subItem.Command},{item.Text} -> {subItem.Text}");
                    }
                }
                else
                    System.Diagnostics.Debug.WriteLine($"{section},{subsection},{item.Command},{item.Text}");
            }

            Assert.IsTrue(menuSystem.RootMenu != null);
        }

        //[TestMethod]
        //public void RipModules()
        //{
        //    string section = "Section";
        //    string subsection = "SubSection";
        //    ModuleMenuReader menuSystem = new ModuleMenuReader("TestModule.xml");

        //    StringBuilder builder = new StringBuilder();
        //    string folderPath = @"C:\Personal\InfoVest\SPC\History\2018\07\SPC Command Menu System\SearchModule";
        //    IEnumerable<string> files = System.IO.Directory.EnumerateFiles(folderPath, "*.xml");

        //    foreach (var file in files)
        //    {
        //        foreach (var item in menuSystem.RootMenu.Menus)
        //        {
        //            if (item.Menus.Length > 0)
        //            {
        //                foreach (var subItem in item.Menus)
        //                {
        //                    builder.AppendLine($"{section},{subsection},{subItem.Command},{item.Text} -> {subItem.Text}");
        //                    //System.Diagnostics.Debug.WriteLine($"{section},{subsection},{subItem.Command},{item.Text} -> {subItem.Text}");
        //                }
        //            }
        //            else
        //                builder.AppendLine($"{section},{subsection},{item.Command},{item.Text}");
        //                //System.Diagnostics.Debug.WriteLine($"{section},{subsection},{item.Command},{item.Text}");
        //        }
        //    }

        //    Assert.IsTrue(menuSystem.RootMenu != null);
        //}

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
