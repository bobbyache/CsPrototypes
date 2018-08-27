using NUnit.Framework;
using PrototypeApp;
using PrototypeApp.AOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestFixture]
    public class Class1
    {
        //[Test]
        //public void Test()
        //{
        //    Startup startup = new Startup();
        //    startup.Start();
        //}

        //[Test]
        //public void GetTodaysTrades_UserIsPermittedToViewTrades_TradesAreReturned()
        //{
        //    PermissionsStub.IsUserPermittedToContinue = true;

        //    Startup startup = new Startup();
        //    startup.Start();
        //    startup.Login();
        //}

        [Test]
        public void GetTodaysTrades_UserIsNotPermittedToViewTrades_SecurityExceptionThrown()
        {
            PermissionsStub.IsUserPermittedToContinue = false;

            Startup startup = new Startup();
            startup.Start();
            

            Assert.Throws<SecurityException>(() => startup.Login());
        }
    }
}
