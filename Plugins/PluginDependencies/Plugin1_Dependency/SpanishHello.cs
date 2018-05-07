using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin1_Dependency
{
    public class SpanishHello
    {
        public static string SayHelloTo(string personName)
        {
            string hello = string.Format("Hola {0} from Dependency.", personName);

            return hello;
        }
    }
}
