using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQStudy.LinqToObjects.Entities;

namespace LINQStudy.LinqToObjects
{
    public class LinqGrouping
    {
        // http://www.codeproject.com/Articles/35667/How-to-Use-LINQ-GroupBy

        //private static void PrintHrEmployees()
        //{
        //    List<HrEmployee> empList = HrEmployee.HrEmployees();
        //    // Printing the List 
        //    Console.WriteLine("\n{0,2} {1,7}    {2,8}      {3,8}      {4,23}      {5,3}",
        //                      "ID", "FName", "MName", "LName", "DOB", "Sex");
        //    empList.ForEach(delegate(HrEmployee e)
        //    {
        //        Console.WriteLine("{0,2} {1,7}    {2,8}      {3,8}      {4,23}    {5,3}",
        //                          e.ID, e.FName, e.MName, e.LName, e.DOB, e.Sex);
        //    }); 

        //}


        public static void GroupEmployeesByFirstLetter()
        {
            //To display a list of employees group by the first alphabet of their first name, use this query:
            // Group People by the First Letter of their FirstName 

            List<HrEmployee> empList = HrEmployee.HrEmployees();

            //var grpOrderedFirstLetter = empList.GroupBy(employees =>
            //    new String(employees.FName[0], 1)).OrderBy(employees =>
            //    employees.Key.ToString()); ;

            // new string(employees.FName[0], 1) becomes the Key... 
            var grpOrderedFirstLetter = empList.GroupBy(employees =>
                new string(employees.FName[0], 1)).OrderBy(employees =>
                    employees.Key.ToString());

            foreach (var employee in grpOrderedFirstLetter)
            {
                Console.WriteLine("\n'Employees having First Letter {0}':",
                                  employee.Key.ToString());
                foreach (var empl in employee)
                {
                    Console.WriteLine(empl.FName);
                }
            } 

        }

        public static void GroupByNumberComparerAndDate()
        {
            MyFounderNumberComparer comp = new MyFounderNumberComparer();
            EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

            //IEnumerable<IGrouping<int, DateTime>> opts = empOptions
            //.GroupBy(o => o.id, o => o.dateAwarded, comp);

            IEnumerable<IGrouping<int, DateTime>> opts =
                empOptions.GroupBy(o => o.id, o => o.dateAwarded, comp);

            // First enumerate through the sequence of IGroupings.
            foreach (IGrouping<int, DateTime> keyGroup in opts)
            {
                Console.WriteLine("Option records for: " +
                (comp.isFounder(keyGroup.Key) ? "founder" : "non-founder"));
                // Now enumerate through the grouping's sequence of EmployeeOptionEntry elements.
                foreach (DateTime date in keyGroup)
                    Console.WriteLine(date.ToShortDateString());
            }
        }

        public static void GroupByDateTime()
        {
            EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();
            IEnumerable<IGrouping<int, DateTime>> opts = empOptions
            .GroupBy(o => o.id, e => e.dateAwarded);

            // First enumerate through the sequence of IGroupings.
            foreach (IGrouping<int, DateTime> keyGroup in opts)
            {
                Console.WriteLine("Option records for employee: " + keyGroup.Key);
                // Now enumerate through the grouping's sequence of DateTime elements.
                foreach (DateTime date in keyGroup)
                    Console.WriteLine(date.ToShortDateString());
            }
        }

        public static void GroupByNumberComparer()
        {
            MyFounderNumberComparer comp = new MyFounderNumberComparer();
            EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

            IEnumerable<IGrouping<int, EmployeeOptionEntry>> opts = empOptions.GroupBy(eo => eo.id, comp);

            // First enumerate through the sequence of IGroupings.
            foreach (IGrouping<int, EmployeeOptionEntry> keyGroup in opts)
            {
                Console.WriteLine("Option records for: " +
                (comp.isFounder(keyGroup.Key) ? "founder" : "non-founder"));

                // Now enumerate through the grouping's sequence of EmployeeOptionEntry elements.
                foreach (EmployeeOptionEntry element in keyGroup)
                    Console.WriteLine("id={0} : optionsCount={1} : dateAwarded={2:d}",
                    element.id, element.optionsCount, element.dateAwarded);
            }
        }

        public static void GroupBy()
        {
            EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();
            IEnumerable<IGrouping<int, EmployeeOptionEntry>> outerSequence =
            empOptions.GroupBy(o => o.id);

            // First enumerate through the outer sequence of IGroupings.
            foreach (IGrouping<int, EmployeeOptionEntry> keyGroupSequence in outerSequence)
            {
                Console.WriteLine("");
                Console.WriteLine("Option records for employee: " + keyGroupSequence.Key);
                Console.WriteLine("-------------------------------------");

                // Now enumerate through the grouping's sequence of EmployeeOptionEntry elements.
                foreach (EmployeeOptionEntry element in keyGroupSequence)
                    Console.WriteLine("id={0} : optionsCount={1} : dateAwarded={2:d}",
                    element.id, element.optionsCount, element.dateAwarded);
            }
        }
    }
}
