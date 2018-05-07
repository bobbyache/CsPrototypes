using Plugin1_Dependency;
using PluginContract;
using System;
using System.ComponentModel.Composition;

namespace Plugin1
{
    [Export(typeof(IPlugin))]
    public class Plugin : BasePlugin
    {
        public Plugin()
            : base("Plugin1")
        {
            Console.WriteLine("ctor_{0}", Name);
        }

        public override string SayHelloTo(string personName)
        {
            string hello = string.Format("Hello {0} from {1}.", personName, Name);
            hello = string.Format("{0}{1}", hello, SpanishHello.SayHelloTo(personName));

            return hello;
        }

        public override void Dispose()
        {
            Console.WriteLine("dispose_{0}", Name);
        }
    }
}
