using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeApp
{
    public class UserLogin : IUserLogin
    {
        public void Login()
        {
            System.Diagnostics.Debug.WriteLine("User has been logged in.");
        }
    }
}
