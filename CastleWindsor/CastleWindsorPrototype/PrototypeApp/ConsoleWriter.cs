using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeApp
{
    public class ConsoleWriter : IConsoleWriter
    {
        readonly ISingletonDemo singletonDemo;

        public ConsoleWriter(ISingletonDemo singletonDemo)
        {
            this.singletonDemo = singletonDemo;
        }

        public void LogMessage(string message)
        {
            System.Diagnostics.Debug.WriteLine("ConsoleWriter.LogMessage:  singletonDemo.ObjectId={0}",
                              singletonDemo.ObjectId);
            System.Diagnostics.Debug.WriteLine(message);
        }
    }
}
