using LINQStudy.LinqToObjects.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQStudy.LinqToObjects.Code
{
    public class LinqSetOperators
    {
        public static void ExceptSetOperator()
        {
            string[] fruits = { "apple", "apricot", "banana", "strawberry" };
            string[] fruitsWithLongNames = { "strawberry" };

            IEnumerable<string> fruitsWithShortNames = fruits.Except(fruitsWithLongNames);

            Console.WriteLine("Using the default equality comparer:");
            foreach (string fruit in fruitsWithShortNames)
            {
                Console.WriteLine(" - {0}", fruit);
            }
        }

        public static void ExceptSetOperatorWithEqualityComparer()
        {
            // huh? here's why: https://mariusschulz.com/blog/why-enumerableexcept-might-not-work-the-way-you-might-expect

            string[] fruits = { "apple", "banana", "cherry", "strawberry" };
            string[] fruitsWithLongNames = { "strawberry" };

            var stringLengthComparer = new StringLengthEqualityComparer();
            IEnumerable<string> fruitsWithShortNames = fruits
                .Except(fruitsWithLongNames, stringLengthComparer);

            Console.WriteLine("Using our custom equality comparer:");
            foreach (string fruit in fruitsWithShortNames)
            {
                Console.WriteLine(" - {0}", fruit);
            }
        }
    }
}
