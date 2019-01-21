using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nwind;
using System.Data.Linq;

namespace LINQStudy.LinqToSql
{
    public class StandardOperations
    {

        public static void UseOverrides()
        {
            Northwind db = new Northwind(AdoNet.ConnectString);

            Shipper ship = (from s in db.Shippers
                            where s.ShipperID == 1
                            select s).Single<Shipper>();

            ship.CompanyName = "Jiffy Shipping";

            Shipper newShip =
            new Shipper
            {
                ShipperID = 4,
                CompanyName = "Vickey Rattz Shipping",
                Phone = "(800) SHIP-NOW"
            };

            db.Shippers.InsertOnSubmit(newShip);
            Shipper deletedShip = (from s in db.Shippers
                                   where s.ShipperID == 3
                                   select s).Single<Shipper>();

            db.Shippers.DeleteOnSubmit(deletedShip);
            db.SubmitChanges();
        }

        public static void RemoveRelationship()
        {
            Northwind db = new Northwind(AdoNet.ConnectString);

            // Retrieve an order to unrelate.
            Order order = (from o in db.Orders
                           where o.OrderID == 11043
                           select o).Single<Order>();

            // Save off the original customer so I can set it back.
            Customer c = order.Customer;
            Console.WriteLine("Orders before deleting the relationship:");

            foreach (Order ord in c.Orders)
                Console.WriteLine("OrderID = {0}", ord.OrderID);

            // Remove the relationship to the customer.
            order.Customer = null;
            db.SubmitChanges();

            Console.WriteLine("{0}Orders after deleting the relationship:",
            System.Environment.NewLine);

            foreach (Order ord in c.Orders)
                Console.WriteLine("OrderID = {0}", ord.OrderID);

            // Restore the database back to its original state.
            order.Customer = c;
            db.SubmitChanges();
        }

        public static void Delete()
        {
            /*
             Caution: Unlike all the other examples in this chapter, this example will not restore the database at the end.
            This is because one of the tables involved contains an identity column, and it is not a simple matter to programmatically
            restore the data to its identical state prior to the example executing. Therefore, before running this example,
            make sure you have a backup of your database that you can restore from. If you downloaded the zipped extended
            version of the Northwind database, after running this example, you could just detach the Northwind database, re-extract
            the database files, and reattach the database.
             */

            Northwind db = new Northwind(AdoNet.ConnectString);

            // Retrieve a customer to delete.
            Customer customer = (from c in db.Customers
                                 where c.CompanyName == "Alfreds Futterkiste"
                                 select c).Single<Customer>();

            // deleting everything from order details through orders, and finally this customer.
            // note SelectMany() to remove all OrderDetails!
            db.OrderDetails.DeleteAllOnSubmit(customer.Orders.SelectMany(o => o.OrderDetails));
            db.Orders.DeleteAllOnSubmit(customer.Orders);
            db.Customers.DeleteOnSubmit(customer);

            db.SubmitChanges();

            Customer customer2 = (from c in db.Customers
                                  where c.CompanyName == "Alfreds Futterkiste"
                                  select c).SingleOrDefault<Customer>();

            Console.WriteLine("Customer {0} found.", customer2 != null ? "is" : "is not");
        }

        public static void AssignNewChildReference()
        {
            Northwind db = new Northwind(AdoNet.ConnectString);
            Order order = (from o in db.Orders
                           where o.EmployeeID == 5
                           orderby o.OrderDate descending
                           select o).First<Order>();

            // Save off the current employee so I can reset it at the end.
            Employee origEmployee = order.Employee;
            Console.WriteLine("Before changing the employee.");
            Console.WriteLine("OrderID = {0} : OrderDate = {1} : EmployeeID = {2}",

            order.OrderID, order.OrderDate, order.Employee.EmployeeID);
            Employee emp = (from e in db.Employees
                            where e.EmployeeID == 9
                            select e).Single<Employee>();

            // Remove the order from the original employee's Orders.
            origEmployee.Orders.Remove(order);

            // Now add it to the new employee's orders.
            emp.Orders.Add(order);
            db.SubmitChanges();

            Console.WriteLine("{0}After changing the employee.", System.Environment.NewLine);
            Console.WriteLine("OrderID = {0} : OrderDate = {1} : EmployeeID = {2}",
                order.OrderID, order.OrderDate, order.Employee.EmployeeID);

            // Now I need to reverse the changes so the example can be run multiple times.
            order.Employee = origEmployee;
            db.SubmitChanges();
        }

        public static void AssignNewParentRelationship()
        {
            Northwind db = new Northwind(AdoNet.ConnectString);

            // get most recent order for this employee
            Order order = (from o in db.Orders
                           where o.EmployeeID == 5
                           orderby o.OrderDate descending
                           select o).First<Order>();

            // Save off the current employee so I can reset it at the end.
            Employee origEmployee = order.Employee;

            Console.WriteLine("Before changing the employee.");
            Console.WriteLine("OrderID = {0} : OrderDate = {1} : EmployeeID = {2}",
                order.OrderID, order.OrderDate, order.Employee.EmployeeID);

            // retrieve another existing employee
            Employee emp = (from e in db.Employees
                            where e.EmployeeID == 9
                            select e).Single<Employee>();

            // Now I will assign the new employee to the order.
            order.Employee = emp;
            db.SubmitChanges();

            // retrieve this order again.
            Order order2 = (from o in emp.Orders
                            where o.OrderID == order.OrderID
                            select o).First<Order>();

            // note new employee relationship
            Console.WriteLine("{0}After changing the employee.", System.Environment.NewLine);
            Console.WriteLine("OrderID = {0} : OrderDate = {1} : EmployeeID = {2}",
                order2.OrderID, order2.OrderDate, order2.Employee.EmployeeID);

            // Now I need to reverse the changes so the example can be run multiple times.
            order.Employee = origEmployee;
            db.SubmitChanges();
        }

        public static void Contains()
        {
            // Equivalent of the IN operator in SQL

            Northwind db = new Northwind(AdoNet.ConnectString);
            db.Log = Console.Out;

            // P.442 - Pro LINQ 2008
            // a little confusing, it seems to work backwards:
            // instead of writing the query so that the customer’s city must be 
            //in some set of values, you write the query so that some set of values 
            //contains the customer’s city
            string[] cities = { "London", "Madrid" };
            IQueryable<Customer> custs = db.Customers.Where(c => cities.Contains(c.City));

            foreach (Customer cust in custs)
                Console.WriteLine("{0} - {1}", cust.CustomerID, cust.City);
        }


        public static void ProgrammaticallyBuiltQuery()
        {
            Northwind db = new Northwind(AdoNet.ConnectString);
            // Turn on the logging.
            db.Log = Console.Out;

            // Pretend the values below are not hardcoded, but instead, obtained by accessing
            // a dropdown list's selected value.
            string dropdownListCityValue = "Cowes";
            string dropdownListCountryValue = "UK";

            IQueryable<Customer> custs = (from c in db.Customers
                                          select c);

            if (!dropdownListCityValue.Equals("[ALL]"))
            {
                custs = from c in custs
                        where c.City == dropdownListCityValue
                        select c;
            }
            if (!dropdownListCountryValue.Equals("[ALL]"))
            {
                custs = from c in custs
                        where c.Country == dropdownListCountryValue
                        select c;
            }

            foreach (Customer cust in custs)
                Console.WriteLine("{0} - {1} - {2}", cust.CompanyName, cust.City, cust.Country);
        }

        public static void OuterJoin()
        {
            Northwind db = new Northwind(AdoNet.ConnectString);

            var entities = from s in db.Suppliers
                           join c in db.Customers on s.City equals c.City into temp
                           from t in temp.DefaultIfEmpty()
                           select new { s, t };

            foreach (var e in entities)
            {
                Console.WriteLine("{0}: {1} - {2}", e.s.City,
                e.s.CompanyName,
                e.t != null ? e.t.CompanyName : "");
            }
        }

        public static void OuterJoinFlattened()
        {
            Northwind db = new Northwind(AdoNet.ConnectString);
            db.Log = Console.Out;

            var entities = from s in db.Suppliers
                           join c in db.Customers on s.City equals c.City into temp
                           from t in temp.DefaultIfEmpty()
                           select new
                           {
                               SupplierName = s.CompanyName,
                               CustomerName = t.CompanyName,
                               City = s.City
                           };

            foreach (var e in entities)
                Console.WriteLine("{0}: {1} - {2}", e.City, e.SupplierName, e.CustomerName);
        }


        public static void InnerJoin()
        {
            Northwind db = new Northwind(AdoNet.ConnectString);

            var entities = from s in db.Suppliers
                           join c in db.Customers on s.City equals c.City
                           select new
                           {
                               SupplierName = s.CompanyName,
                               CustomerName = c.CompanyName,
                               City = c.City
                           };


            foreach (var e in entities)
                Console.WriteLine("{0}: {1} - {2}", e.City, e.SupplierName, e.CustomerName);

        }

        public static void DeferredLoad()
        {
            //Deferred query execution refers to the fact that a LINQ query of any type—be it a LINQ to SQL
            //query, a LINQ to XML query, or a LINQ to Objects query—may not actually be executed at the time
            //it is defined.

            //deferred loading is the default behaviour for associated classes.
            Northwind db = new Northwind(AdoNet.ConnectString);
            IQueryable<Customer> custs = from c in db.Customers
                                         where c.Country == "UK" &&
                                         c.City == "London"
                                         orderby c.CustomerID
                                         select c;
            // Turn on the logging.
            db.Log = Console.Out;
            foreach (Customer cust in custs)
            {
                Console.WriteLine("{0} - {1}", cust.CompanyName, cust.ContactName);
                foreach (Order order in cust.Orders)
                {
                    Console.WriteLine(" {0} {1}", order.OrderID, order.OrderDate);
                }
            }
        }

        public static void ImmediateLoad()
        {
            Northwind db = new Northwind(AdoNet.ConnectString);

            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<Customer>(c => c.Orders);
            db.LoadOptions = dlo;

            IQueryable<Customer> custs = (from c in db.Customers
                                          where c.City == "UK" && c.City == "London"
                                          orderby c.CustomerID
                                          select c);

            // Turning on the logging
            db.Log = Console.Out;

            foreach (Customer cust in custs)
                Console.WriteLine("{0} - {1}", cust.CompanyName, cust.ContactName);
        }

        public static void ImmediateLoadMultiple()
        {
            Northwind db = new Northwind(AdoNet.ConnectString);

            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<Customer>(c => c.Orders);
            dlo.LoadWith<Customer>(c => c.CustomerCustomerDemos);
            db.LoadOptions = dlo;

            IQueryable<Customer> custs = (from c in db.Customers
                                          where c.Country == "UK" && c.City == "London"
                                          orderby c.CustomerID
                                          select c);

            // Turn on the logging
            db.Log = Console.Out;

            foreach (Customer cust in custs)
                Console.WriteLine("{0} - {1}", cust.CompanyName, cust.ContactName);
        }

        public static void ImmediateLoadHierarchy()
        {
            Northwind db = new Northwind(AdoNet.ConnectString);

            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<Customer>(c => c.Orders);
            dlo.LoadWith<Order>(o => o.OrderDetails);
            db.LoadOptions = dlo;

            IQueryable<Customer> custs = (from c in db.Customers
                                          where c.Country == "UK" &&
                                          c.City == "London"
                                          orderby c.CustomerID
                                          select c);

            // Turn on the logging.
            db.Log = Console.Out;

            foreach (Customer cust in custs)
            {
                Console.WriteLine("{0} - {1}", cust.CompanyName, cust.ContactName);
                foreach (Order order in cust.Orders)
                {
                    Console.WriteLine(" {0} {1}", order.OrderID, order.OrderDate);
                }
            }
        }

        public static void LoadWithFilterAndOrdering()
        {
            Northwind db = new Northwind(AdoNet.ConnectString);

            DataLoadOptions dlo = new DataLoadOptions();
            dlo.AssociateWith<Customer>(c => from o in c.Orders
                                             where o.OrderID < 10700
                                             orderby o.OrderDate descending
                                             select o);
            db.LoadOptions = dlo;

            IQueryable<Customer> custs = from c in db.Customers
                                         where c.Country == "UK" && c.City == "London"
                                         select c;

            foreach (Customer cust in custs)
            {
                Console.WriteLine("{0} - {1}", cust.CompanyName, cust.ContactName);

                foreach (Order order in cust.Orders)
                    Console.WriteLine(" {0} {1}", order.OrderID, order.OrderDate);
            }
        }

        public static void SelectCustomerOrders()
        {
            Northwind db = new Northwind(AdoNet.ConnectString);

            IQueryable<Customer> custs = (from c in db.Customers
                                          where c.Country == "UK" &&
                                          c.City == "London"
                                          orderby c.CustomerID
                                          select c);

            foreach (Customer cust in custs)
            {
                Console.WriteLine("{0} - {1}", cust.CompanyName, cust.ContactName);

                // deferred loading...
                foreach (Order order in cust.Orders)
                    Console.WriteLine(" {0} {1}", order.OrderID, order.OrderDate);
            }
        }

        public static void SelectCustomersInLondon()
        {
            Northwind db = new Northwind(AdoNet.ConnectString);

            IQueryable<Customer> customers = (from c in db.Customers
                                              where c.City == "London"
                                              select c);

            // if you're trying to treat IQueryable<T> like an IEnumerable<T> then remember to use "AsEnumerable".
            //IEnumerable<Customer> customers2 = customers.AsEnumerable();

            foreach (Customer cust in customers)
                Console.WriteLine("Customer: {0}", cust.CompanyName);
        }

        public static void InsertAttachedOrder()
        {
            Northwind db = new Northwind(AdoNet.ConnectString);

            Customer cust =
                new Customer
                {
                    CustomerID = "LAWN",
                    CompanyName = "Lawn Wranglers",
                    ContactName = "Mr. Abe Henry",
                    ContactTitle = "Owner",
                    Address = "1017 Maple Leaf Way",
                    City = "Ft. Worth",
                    Region = "TX",
                    PostalCode = "76104",
                    Country = "USA",
                    Phone = "(800) MOW-LAWN",
                    Fax = "(800) MOW-LAWO",
                    Orders = {
                        new Order {
                        CustomerID = "LAWN",
                        EmployeeID = 4,
                        OrderDate = DateTime.Now,
                        RequiredDate = DateTime.Now.AddDays(7),
                        ShipVia = 3,
                        Freight = new Decimal(24.66),
                        ShipName = "Lawn Wranglers",
                        ShipAddress = "1017 Maple Leaf Way",
                        ShipCity = "Ft. Worth",
                        ShipRegion = "TX",
                        ShipPostalCode = "76104",
                        ShipCountry = "USA"
                        }
                    }
                };

            db.Customers.InsertOnSubmit(cust);
            db.SubmitChanges();

            Customer customer = db.Customers.Where(c => c.CustomerID == "LAWN").First();
            Console.WriteLine("{0} - {1}", customer.CompanyName, customer.ContactName);

            foreach (Order order in customer.Orders)
            {
                Console.WriteLine("{0} - {1}", order.CustomerID, order.OrderDate);
            }

            // This part of the code merely resets the database so the example can be
            // run more than once.
            db.Orders.DeleteOnSubmit(cust.Orders.First());
            db.Customers.DeleteOnSubmit(cust);
            db.SubmitChanges();
        }

        public static void InsertOrderUsingEntitySet()
        {
            Northwind db = new Northwind(AdoNet.ConnectString);

            Customer cust = (from c in db.Customers
                             where c.CustomerID == "LONEP"
                             select c).Single<Customer>();

            // Used to query record back out.
            DateTime now = DateTime.Now;

            Order order = new Order
            {
                CustomerID = cust.CustomerID,
                EmployeeID = 4,
                OrderDate = now,
                RequiredDate = DateTime.Now.AddDays(7),
                ShipVia = 3,
                Freight = new Decimal(24.46),
                ShipName = cust.CompanyName,
                ShipAddress = cust.City,
                ShipRegion = cust.Region,
                ShipPostalCode = cust.PostalCode,
                ShipCountry = cust.Country
            };

            cust.Orders.Add(order);
            db.SubmitChanges();

            IEnumerable<Order> orders = db.Orders.Where(o => cust.CustomerID == "LONEP" && o.OrderDate.Value == now);

            foreach (Order o in orders)
                Console.WriteLine("{0} {1}", o.OrderDate, o.ShipName);

            // This part of the code merely resets the database so the example can be
            // run more than once.
            db.Orders.DeleteOnSubmit(order);
            db.SubmitChanges();
        }

        public static void InsertCustomer()
        {
            // 1. Create the DataContext.
            Northwind db = new Northwind(AdoNet.ConnectString);

            // 2. Instantiate an entity object.
            Customer cust =
            new Customer
            {
                CustomerID = "LAWN",
                CompanyName = "Lawn Wranglers",
                ContactName = "Mr. Abe Henry",
                ContactTitle = "Owner",
                Address = "1017 Maple Leaf Way",
                City = "Ft. Worth",
                Region = "TX",
                PostalCode = "76104",
                Country = "USA",
                Phone = "(800) MOW-LAWN",
                Fax = "(800) MOW-LAWO"
            };
            // 3. Add the entity object to the Customers table.
            db.Customers.InsertOnSubmit(cust);
            // 4. Call the SubmitChanges method.
            db.SubmitChanges();

            // 5. Query the record.
            Customer customer = db.Customers.Where(c => c.CustomerID == "LAWN").First();
            Console.WriteLine("{0} - {1}", customer.CompanyName, customer.ContactName);

            // This part of the code merely resets the database so the example can be
            // run more than once.
            Console.WriteLine("Deleting the added customer LAWN.");
            db.Customers.DeleteOnSubmit(cust);
            db.SubmitChanges();
        }
    }
}
