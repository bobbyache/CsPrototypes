using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQStudy.LinqToSql;

namespace LINQStudy.LinqToObjects
{
    public class LinqPartitioning
    {
        public static void OrderingThenByWithIComparer()
        {
            string[] presidents = ObjectLists.GetPresidents();
            ConsoleCmd.PrintHeader("Order By , Then By using IComparer");

            MyVowelToConsonantRatioComparer myComp = new MyVowelToConsonantRatioComparer();

            // Can also use ThenByDescending
            IEnumerable<string> namesByVToCRatio = presidents
                .OrderBy(n => n.Length)
                .ThenBy((s => s), myComp);

            foreach (string item in namesByVToCRatio)
            {
                int vCount = 0;
                int cCount = 0;
                myComp.GetVowelConsonantCount(item, ref vCount, ref cCount);
                double dRatio = (double)vCount / (double)cCount;
                Console.WriteLine(item + " - " + dRatio + " - " + vCount + ":" + cCount);
            }
        }

        public static void BasicOrderingThenBy()
        {
            string[] presidents = ObjectLists.GetPresidents();
            ConsoleCmd.PrintHeader("Order By , Then By");

            IEnumerable<string> items = presidents.OrderBy(s => s.Length).ThenBy(s => s);
            foreach (string item in items)
                Console.WriteLine(item);
        }

        public static void OrderingWithIComparer()
        {
            string[] presidents = ObjectLists.GetPresidents();
            ConsoleCmd.PrintHeader("Order By using IComparer");

            MyVowelToConsonantRatioComparer myComp = new MyVowelToConsonantRatioComparer();

            IEnumerable<string> namesByVToCRatio = presidents.OrderBy(s => s, myComp);

            foreach (string item in namesByVToCRatio)
            {
                int vCount = 0;
                int cCount = 0;
                myComp.GetVowelConsonantCount(item, ref vCount, ref cCount);

                double dRatio = (double)vCount / (double)cCount;
                Console.WriteLine(item + " - " + dRatio + " - " + vCount + ":" + cCount);
            }
        }

        public static void OrderDescendingWithIComparer()
        {
            string[] presidents = ObjectLists.GetPresidents();
            ConsoleCmd.PrintHeader("Order By using IComparer");

            MyVowelToConsonantRatioComparer myComp = new MyVowelToConsonantRatioComparer();

            IEnumerable<string> namesByVToCRatio = presidents.OrderByDescending(s => s, myComp);

            foreach (string item in namesByVToCRatio)
            {
                int vCount = 0;
                int cCount = 0;
                myComp.GetVowelConsonantCount(item, ref vCount, ref cCount);

                double dRatio = (double)vCount / (double)cCount;
                Console.WriteLine(item + " - " + dRatio + " - " + vCount + ":" + cCount);
            }
        }

        public static void BasicOrdering()
        {
            string[] presidents = ObjectLists.GetPresidents();
            ConsoleCmd.PrintHeader("Order By Method");

            //IEnumerable<string> items = presidents.OrderBy(s => s.Length);
            //foreach (string item in items)
            //    Console.WriteLine(item);

            IEnumerable<string> items = presidents.OrderBy(s => s.Length);
            foreach (string item in items)
                Console.WriteLine(item);
        }

        public static void BasicConcat()
        {
            string[] presidents = ObjectLists.GetPresidents();
            ConsoleCmd.PrintHeader("Concat Method");

            IEnumerable<string> items = presidents.Take(5).Concat(presidents.Skip(5));
            foreach (string item in items)
                Console.WriteLine(item);
        }

        public static void ConcatWithoutConcat()
        {
            string[] presidents = ObjectLists.GetPresidents();
            ConsoleCmd.PrintHeader("Concat without Concat");

            // May be useful when concatenating more than two sequences together.
            // Consider using the SelectMany approach.

            // explanation of weird arrays within an array... a jagged array...
            // http://msdn.microsoft.com/en-us/library/bb384090.aspx
            IEnumerable<string> items =
                new[] {
                    presidents.Take(5), presidents.Skip(5)
                }.SelectMany(s => s);

            foreach (string item in items)
                Console.WriteLine(item);
        }

        public static void BasicTake()
        {
            string[] presidents = ObjectLists.GetPresidents();
            ConsoleCmd.PrintHeader("Take Method");

            //IEnumerable<string> items = presidents.Take(5);
            //foreach (string item in items)
            //    Console.WriteLine(item);

            //IEnumerable<string> items = presidents.Take(5);
            //foreach (string item in items)
            //    Console.WriteLine(item);

            IEnumerable<string> items = presidents.Take(5);
            foreach (string item in items)
                Console.WriteLine(item);
        }

        public static void EfficientTake()
        {
            string[] presidents = ObjectLists.GetPresidents();
            ConsoleCmd.PrintHeader("Efficient Take Method");

            //IEnumerable<char> chars = presidents
            //    .SelectMany((p, i) => i < 5 ? p.ToArray() : new char[] { });

            //foreach (char ch in chars)
            //    Console.WriteLine(ch);

            //IEnumerable<char> chars = presidents.Take(5).SelectMany(s => s.ToArray());

            //foreach (char ch in chars)
            //    Console.WriteLine(ch);

            //IEnumerable<char> chars = presidents.Take(5).SelectMany(s => s.ToCharArray());
            IEnumerable<char> chars = presidents.Take(5).SelectMany(s => s.ToCharArray());
            foreach (char ch in chars)
                Console.WriteLine(ch);


        }

        public static void BasicTakeWhile()
        {
            // opposite of Skip and SkipWhile

            string[] presidents = ObjectLists.GetPresidents();
            ConsoleCmd.PrintHeader("Basic Take While Method");


            //IEnumerable<string> items = presidents.TakeWhile(s => s.Length < 10);
            //foreach (string item in items)
            //    Console.WriteLine(item);

            // This example will stop when an input element exceeds nine characters in length or when the
            // sixth element is reached, whichever comes first.
            IEnumerable<string> items = presidents
                .TakeWhile((s, i) => s.Length < 10 && i < 5);
            foreach (string item in items)
                Console.WriteLine(item);
        }

        public static void WhereVsTakeWhile()
        {
            // TakeWhile stops when the condition is false, 
            //Where continues and find all elements matching the condition
            var intList = new int[] { 1, 2, 3, 4, 5, -1, -2 };

            Console.WriteLine("Where");
            foreach (var i in intList.Where(x => x <= 3))
                Console.WriteLine(i);

            Console.WriteLine("TakeWhile");
            foreach (var i in intList.TakeWhile(x => x <= 3))
                Console.WriteLine(i); 

        }
    }
}
