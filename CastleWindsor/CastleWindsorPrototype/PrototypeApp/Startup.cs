using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeApp
{
    public class Startup
    {
        public void Start()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<ICompositionRoot>().ImplementedBy<CompositionRoot>());

            var root = container.Resolve<ICompositionRoot>();
            root.LogMessage("Hello from my very first resolved class!");
        }
    }
}
