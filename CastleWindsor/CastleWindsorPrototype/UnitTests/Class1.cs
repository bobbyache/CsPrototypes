using NUnit.Framework;
using PrototypeApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test()
        {
            Startup startup = new Startup();
            startup.Start();
        }
    }
}
