using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

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
            SpcMenuSystem menuSystem = new SpcMenuSystem("ReportsModule.xml");
            Assert.IsInstanceOfType(menuSystem.RootMenu, typeof(SpcMenuItem));
            Assert.AreEqual("&Reports", menuSystem.RootMenu.Text);
        }

        [TestMethod]
        public void GetAllMenus()
        {
            SpcMenuSystem menuSystem = new SpcMenuSystem("ReportsModule.xml");
            Assert.IsTrue(menuSystem.RootMenu.Menus.Length > 0);
        }

        [TestMethod]
        public void GetNameOfModule()
        {
            SpcMenuSystem menuSystem = new SpcMenuSystem("ReportsModule.xml");
            Assert.AreEqual("ReportsModule", menuSystem.Name);
        }

        [TestMethod]
        public void GetDescriptionOfModule()
        {
            SpcMenuSystem menuSystem = new SpcMenuSystem("ReportsModule.xml");
            Assert.AreEqual("Reports Module", menuSystem.Description);
        }

        public class SpcMenuSystem
        {
            private XDocument document;
            private XElement moduleElement;
            

            public SpcMenuSystem(string path)
            {
                document = System.Xml.Linq.XDocument.Load(path);
                moduleElement = document.Element("configuredmodule");

                var rootEntry = (XElement)moduleElement.Element("security").FirstNode;

                GetAllCommandEntries("", rootEntry);
            }

            public string Name => (string)moduleElement.Attribute("name");
            public string Description => (string)moduleElement.Attribute("description");
            public string RequiredUserType => (string)moduleElement.Attribute("required-user-type");

            public SpcMenuItem RootMenu => new SpcMenuItem(moduleElement.Element("menus").Element("menu"), commandEntriesDictionary);

            private Dictionary<string, SpcCommandItem> commandEntriesDictionary = new Dictionary<string, SpcCommandItem>();

            public void GetAllCommandEntries(string parentName, XElement entryElement)
            {
                string name;

                if (string.IsNullOrEmpty(parentName))
                    name = (string)entryElement.Attribute("name");
                else
                    name = $"{parentName}.{(string)entryElement.Attribute("name")}";

                commandEntriesDictionary.Add(name, new SpcCommandItem(entryElement));

                foreach (var child in entryElement.Elements())
                    GetAllCommandEntries(name, child);
            }
        }

        public class SpcCommandItem
        {
            public string Name { get; }
            public string DisplayName { get; }
            public string Execute { get; }
            public string RequiredUserType { get; }

            public SpcCommandItem(XElement element)
            {
                Name = (element.Attribute("name") != null) ? (string)element.Attribute("name") : "";
                DisplayName = (element.Attribute("display-name") != null) ? (string)element.Attribute("display-name") : "";
                Execute = (element.Attribute("execute") != null) ? (string)element.Attribute("execute") : "";
                RequiredUserType = (element.Attribute("required-user-type") != null) ? (string)element.Attribute("required-user-type") : "";
            }
        }

        public class SpcMenuItem
        {
            public string Command { get; }
            public string Text { get; }

            public SpcMenuItem[] Menus { get; }

            public SpcCommandItem CommandItem { get; }

            public SpcMenuItem(XElement element, Dictionary<string, SpcCommandItem> commandDictionary)
            {
                Command = (string)element.Attribute("command");
                Text = (string)element.Attribute("text");
                Menus = element.Elements("menu").Select(m => new SpcMenuItem(m, commandDictionary)).ToArray();

                if (Command != null && commandDictionary.ContainsKey(Command))
                    CommandItem = commandDictionary[Command];
            }
        }
    }
}
