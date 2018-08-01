using System.Xml.Linq;

namespace ModuleXmlReader
{
    public class ModuleCommand
    {
        public string Name { get; }
        public string DisplayName { get; }
        public string Execute { get; }
        public string RequiredUserType { get; }

        public ModuleCommand(XElement element)
        {
            Name = (element.Attribute("name") != null) ? (string)element.Attribute("name") : "";
            DisplayName = (element.Attribute("display-name") != null) ? (string)element.Attribute("display-name") : "";
            Execute = (element.Attribute("execute") != null) ? (string)element.Attribute("execute") : "";
            RequiredUserType = (element.Attribute("required-user-type") != null) ? (string)element.Attribute("required-user-type") : "";
        }
    }
}
