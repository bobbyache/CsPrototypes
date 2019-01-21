using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQStudy.LinqToSql;


namespace LINQStudy.LinqToObjects
{
    public class LinqJoining
    {
        public static void BasicGroupJoin()
        {
            ConsoleCmd.PrintHeader("Basic Group Joining");

            Employee[] employees = Employee.GetEmployeesArray();
            EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

            var employeeOptions = employees
                .GroupJoin(empOptions, e => e.id, eo => eo.id,
                (e, eo) => new
                {
                    id = e.id,
                    name = string.Format("{0} {1}", e.firstName, e.lastName),
                    options = eo.Sum(o => o.optionsCount)
                });

            foreach (var item in employeeOptions)
                Console.WriteLine(item);
        }

        public static void BasicJoin()
        {
            ConsoleCmd.PrintHeader("Basic Joining");

            Employee[] employees = Employee.GetEmployeesArray();
            EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

            var employeeOptions = employees
                .Join(empOptions, e => e.id, eo => eo.id,
                (e, eo) => new
                {
                    id = e.id,
                    name = string.Format("{0} {1}", e.firstName, e.lastName),
                    options = eo.optionsCount
                });

            foreach (var item in employeeOptions)
                Console.WriteLine(item);
        }
    }
}
