using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using PrototypeApp.AOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeApp
{
    public class Startup
    {
        private WindsorContainer container = new WindsorContainer();

        public void Start()
        {
            

            // --------------------------------------------------------------------------------------------------------
            // AOP stuff
            // --------------------------------------------------------------------------------------------------------
            // Register the interceptor itself as if it was any other standard component.
            container.Register(Component.For<IInterceptor>().ImplementedBy<PermissionsInterceptor>().Named("MyInterceptor"));

            // --------------------------------------------------------------------------------------------------------
            // Dependency mapping
            // --------------------------------------------------------------------------------------------------------
            container.Register(Component.For<ICompositionRoot>().ImplementedBy<CompositionRoot>());
            container.Register(Component.For<IConsoleWriter>().ImplementedBy<ConsoleWriter>());
            container.Register(Component.For<IUserLogin>().ImplementedBy<UserLogin>().Interceptors<IInterceptor>());

            // --------------------------------------------------------------------------------------------------------
            // Object life-cycle stuff...
            // --------------------------------------------------------------------------------------------------------
            // register a singleton type... type will exist for as long as the app is alive.
            //container.Register(Component.For<ISingletonDemo>().ImplementedBy<SingletonDemo>());
            // get a shiny new type every time we ask for one.
            container.Register(Component.For<ISingletonDemo>().ImplementedBy<SingletonDemo>().LifestyleTransient());

            var root = container.Resolve<ICompositionRoot>();
            root.LogMessage("Hello from my very first resolved class!");
        }

        public void Login()
        {
            var userLogin = container.Resolve<IUserLogin>();
            userLogin.Login();
        }
    }
}
