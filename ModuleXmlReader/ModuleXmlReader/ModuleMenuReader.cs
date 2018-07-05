using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ModuleXmlReader
{
    public class ModuleMenuReader
    {
        private XDocument document;
        private XElement moduleElement;

        public ModuleMenuReader(string path)
        {
            document = XDocument.Load(path);
            moduleElement = document.Element("configuredmodule");

            var rootEntry = (XElement)moduleElement.Element("security").Element("entry");

            GetAllCommandEntries("", rootEntry);
        }

        public string Name => (string)moduleElement.Attribute("name");
        public string Description => (string)moduleElement.Attribute("description");
        public string RequiredUserType => (string)moduleElement.Attribute("required-user-type");

        public ModuleMenu RootMenu => new ModuleMenu(moduleElement.Element("menus").Element("menu"), commandEntriesDictionary);

        private Dictionary<string, ModuleCommand> commandEntriesDictionary = new Dictionary<string, ModuleCommand>();

        public void GetAllCommandEntries(string parentName, XElement entryElement)
        {
            string name;

            if (string.IsNullOrEmpty(parentName))
                name = (string)entryElement.Attribute("name");
            else
                name = $"{parentName}.{(string)entryElement.Attribute("name")}";

            commandEntriesDictionary.Add(name, new ModuleCommand(entryElement));

            foreach (var child in entryElement.Elements())
                GetAllCommandEntries(name, child);
        }
    }
}
