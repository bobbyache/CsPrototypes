using PluginContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin3
{
    [Export(typeof(IPlugin))]
    public class Plugin : BasePlugin
    {
        [ImportingConstructor]
        public Plugin()
            : base("Plugin3")
        {
            Console.WriteLine("ctor_{0}", Name);
        }

        public override string SayHelloTo(string personName)
        {
            string hello = string.Format("Hello {0} from {1}. From the root folder (no sub-directory)", personName, Name);

            return hello;
        }

        public override void Dispose()
        {
            Console.WriteLine("dispose_{0}", Name);
        }
    }
}
