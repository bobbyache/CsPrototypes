using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginContract
{
    public abstract class BasePlugin : MarshalByRefObject, IPlugin
    {
        public BasePlugin(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public abstract string SayHelloTo(string personName);

        public virtual void Dispose()
        {
            //TODO:
        }
    }
}
