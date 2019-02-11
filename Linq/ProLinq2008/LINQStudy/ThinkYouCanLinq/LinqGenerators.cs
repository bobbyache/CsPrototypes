using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQStudy.ThinkYouCanLinq
{
    public class LinqGenerators
    {
        private static Random random = new Random();

        public static void GenerateRandomNumbers()
        {
            //var numbers = GenerateRandomNumbers(20);
            //var numbers = GenerateRandomNumbers(1980, 2020, 20);
            //foreach (var item in numbers)
            //    Console.Write(item + " ");

            var id = GetUniqueId(20);
            Console.WriteLine(id);
        }

        public static IEnumerable<int> GenerateRandomNumbers(int numberOfElements)
        {
            // range is being used as the values themselves
            return Enumerable.Range(0, numberOfElements - 1).OrderBy(n => random.Next());
        }

        public static IEnumerable<int> GenerateRandomNumbers(int min, int max, int numberOfElements)
        {
            // range is being used as a loop counter
            return Enumerable.Range(0, numberOfElements - 1).Select(n => random.Next(min, max));
        }

        public static string GetUniqueId(int charLength)
        {
            // 65 to 90 = ascii codes.
            var chars = Enumerable.Range(0, charLength - 1).Select(n => (char)random.Next(65, 90));
            return new string(chars.ToArray());
        }
    }
}
