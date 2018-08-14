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
            container.Register(Component.For<IConsoleWriter>().ImplementedBy<ConsoleWriter>());

            // register a singleton type... type will exist for as long as the app is alive.
            //container.Register(Component.For<ISingletonDemo>().ImplementedBy<SingletonDemo>());

            // get a shiny new type every time we ask for one.
            container.Register(Component.For<ISingletonDemo>().ImplementedBy<SingletonDemo>().LifestyleTransient());

            var root = container.Resolve<ICompositionRoot>();
            root.LogMessage("Hello from my very first resolved class!");
        }
    }
}
