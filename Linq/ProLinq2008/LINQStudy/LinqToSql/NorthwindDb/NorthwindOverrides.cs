using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

/*
 Pro Linq 2008 - p.449
     
 Overriding the code called to insert, update, and delete is as simple as defining the appropriately
named partial method with the appropriate signature. When you override this way, the DataContext
change processor will then call your partial method implementation for the database update, insert,
or delete. Here is yet another way Microsoft is taking advantage of partial methods. You get the
ability to hook into the code but with no overhead if you don’t.
            
You must be aware, though, that if you take this approach, you will be responsible for concurrency
conflict detection. Please read Chapter 17 thoroughly before accepting this responsibility.
            
When you define these override methods, it is the name of the partial method and the entity
type of the method’s parameters that instruct the DataContext to call your override methods. Let’s
take a look at the method prototypes you must define to override the insert, update, and delete methods.
*/

//Don’t forget, as I covered in Chapter 13, you can override the insert, update, and delete 
// methods using the Object Relational Designer.

// In many situations, the override will be for the purpose of calling a stored procedure,
// but this is up to the developer.

// to use this partial class the namespace must be the same, and so too must the
// class name. It must also inherit any interfaces, objects like the parent...
namespace nwind
{
    partial class Northwind : DataContext
    {
        partial void InsertShipper(Shipper instance) 
        {
            Console.WriteLine("Insert override method was called for shipper {0}.",
                instance.CompanyName);

            // call the default behaviour after...
            //this.ExecuteDynamicInsert(instance);
        }

        partial void UpdateShipper(Shipper instance)
        {
            Console.WriteLine("Update override method was called for shipper {0}.",
                instance.CompanyName);

            // call the default behaviour after...
            //this.ExecuteDynamicUpdate(instance);
        }

        partial void DeleteShipper(Shipper instance)
        {
            Console.WriteLine("Delete override method was called for shipper {0}.",
                instance.CompanyName);

            // call the default behaviour after...
            //this.ExecuteDynamicDelete(instance);
        }

    }
}
