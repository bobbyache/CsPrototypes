using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ModuleXmlReader
{
    public class ModuleMenu
    {
        public string Command { get; }
        public string Text { get; }

        public ModuleMenu[] Menus { get; }

        public ModuleCommand CommandItem { get; }

        public ModuleMenu(XElement element, Dictionary<string, ModuleCommand> commandDictionary)
        {
            Command = (string)element.Attribute("command");
            Text = (string)element.Attribute("text");
            Menus = element.Elements("menu")
                .Where(m => (m.Attribute("text").Value != "-"))
                .Select(m => new ModuleMenu(m, commandDictionary))
                .ToArray();

            if (Command != null && commandDictionary.ContainsKey(Command))
                CommandItem = commandDictionary[Command];
        }
    }
}
