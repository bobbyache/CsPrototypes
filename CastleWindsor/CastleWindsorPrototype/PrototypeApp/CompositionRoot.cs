using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeApp
{
    public class CompositionRoot : ICompositionRoot
    {
        private readonly IConsoleWriter consoleWriter;
        private readonly ISingletonDemo singletonDemo;
        private readonly IUserLogin userLogin;

        public CompositionRoot(IConsoleWriter consoleWriter, ISingletonDemo singletonDemo, IUserLogin userLogin)
        {
            this.consoleWriter = consoleWriter ?? throw new ArgumentNullException("Console writer must be supplied.");
            this.singletonDemo = singletonDemo ?? throw new ArgumentNullException("Singleton Demo must be supplied.");
            this.userLogin = userLogin ?? throw new ArgumentNullException("User Login must be supplied.");

            consoleWriter.LogMessage("Hello from the CompositionRoot Constructor!");
        }

        public void LogMessage(string message)
        {
            var msg = $"CompositionRoot.LogMessage:  singletonDemo.ObjectId={singletonDemo.ObjectId}";
            consoleWriter.LogMessage(msg);
            consoleWriter.LogMessage(message);
        }

        public void Login()
        {
            userLogin.Login();
        }
    }
}
