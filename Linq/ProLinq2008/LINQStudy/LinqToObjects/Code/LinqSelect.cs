using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQStudy.LinqToSql;

namespace LINQStudy.LinqToObjects
{
    public class LinqSelect
    {
        public static void ReturnAnonymousType()
        {
            string[] presidents = ObjectLists.GetPresidents();

            //ConsoleCmd.PrintHeader("SELECT Method: Return Anonymous Type");
            //// example 1:
            //var nameObjs = presidents.Select((p, i) => new
            //{
            //    p,
            //    p.Length
            //});
            //foreach (var item in nameObjs)
            //    Console.WriteLine(item);


            //ConsoleCmd.PrintHeader("SELECT Method: Return Anonymous Type (properties)");
            //// example 2:
            //var nameObjs2 = presidents.Select(p => new
            //{
            //    LastName = p,
            //    Length = p.Length
            //});
            //foreach (var item in nameObjs2)
            //    Console.WriteLine("{0} is {1} characters long.", item.LastName, item.Length);



            //ConsoleCmd.PrintHeader("SELECT Method: Return Anonymous Type (properties)");
            //// example 3: i incremented as the index.
            //var nameObjs = presidents.Select((p, i) => new
            //{
            //    Index = i,
            //    LastName = p
            //});
            //foreach (var item in nameObjs)
            //    Console.WriteLine("{0}. {1}", item.Index + 1, item.LastName);



            ConsoleCmd.PrintHeader("SELECT Method: Return Anonymous Type (orderby)");
            // example 4: i incremented as the index, ordered by Last Name.
            var nameObjs = presidents.Select((p, i) => new
            {
                Index = i,
                LastName = p
            }).OrderBy(p => p.LastName);

            
            foreach (var item in nameObjs)
                Console.WriteLine("{0}. {1}", item.Index + 1, item.LastName);
        }

        public static void BasicUsingWhere()
        {
            ConsoleCmd.PrintHeader("SELECT Method");
            string[] presidents = ObjectLists.GetPresidents();

            IEnumerable<int> nameLengths = presidents.Where(p => p.StartsWith("J")).Select(p => p.Length);
            foreach (int item in nameLengths)
                Console.WriteLine(item);
        }
    }
}
