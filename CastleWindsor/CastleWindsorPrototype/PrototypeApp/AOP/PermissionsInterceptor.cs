using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeApp.AOP
{
    // IInterceptor is part of Castle Windsor, this is the interface we must fulfil to
    // write our interceptor.  The important method here is Intercept(IInvocation invocation).
    public class PermissionsInterceptor : IInterceptor
    {
        // IInvocation is a wrapper around the method being intercepted and includes
        // valuable meta-data we can use to identify whether any actual should be performed
        // prior to proceeding with the call.
        // Note we can even obtain the properties being passed through to the method here
        // if we wanted to incorporate them into the cross cutting logic.
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Checking Permissions");

            // Here we want to only run permissions checks against public methods
            // This means we don't subsequentially duplicate the calls against private methods
            // internal to the class.
            if (!invocation.Method.IsPublic)
            {
                // Run the intercepted method as normal.
                invocation.Proceed();
            }
            // I'll go through this later, attributes can be used to further augment the
            // flow of intercepted logic.
            else if (AttributeExistsOnMethod<DoNotPerformPermissionCheck>(invocation))
            {
                // Run the intercepted method as normal.
                invocation.Proceed();
            }
            // Mock call checking if the user has the relevant privileges.
            else if (PermissionsStub.IsUserPermittedToContinue)
            {
                // Run the intercepted method as normal.
                invocation.Proceed();
            }
            else
            {
                // As we haven't run Proceed, the wrapped invocation will not be run.
                throw new SecurityException("The user is not permitted to run this method");
            }
        }

        private static bool AttributeExistsOnMethod<AttributeToCheck>(IInvocation invocation)
        {
            var attribute = Attribute.GetCustomAttribute(
                                invocation.Method,
                                typeof(AttributeToCheck),
                                true);

            return attribute != null;
        }
    }
}
