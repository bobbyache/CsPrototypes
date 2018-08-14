using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeApp
{
    public class CompositionRoot : ICompositionRoot
    {
        public void LogMessage(string message)
        {
            //Console.WriteLine(message);
            System.Diagnostics.Debug.WriteLine(message);
        }
    }
}
