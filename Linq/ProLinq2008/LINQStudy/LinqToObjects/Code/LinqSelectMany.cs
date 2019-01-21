using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQStudy.LinqToSql;


namespace LINQStudy.LinqToObjects
{
    public class LinqSelectMany
    {
        public static void BasicSyntax()
        {
            string[] presidents = ObjectLists.GetPresidents();
            ConsoleCmd.PrintHeader("SELECTMANY Basic Syntax");

            //IEnumerable<char> chars = presidents.SelectMany(p => p.ToArray());
            //foreach (char ch in chars)
            //    Console.WriteLine(ch);

            IEnumerable<char> chars = presidents.SelectMany(p => p.ToCharArray());
            foreach (char ch in chars)
                Console.WriteLine(ch);
        }

        public static void SelectEmployeeOptions()
        {
            Employee[] employees = Employee.GetEmployeesArray();
            EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

            var employeeOptions = employees
                .SelectMany(e => empOptions.Where(eo => e.id == eo.id)
                    .Select(eo => new { id = eo.id, optionsCount = eo.optionsCount }));

            foreach (var item in employeeOptions)
                Console.WriteLine(item);
        }
    }
}
