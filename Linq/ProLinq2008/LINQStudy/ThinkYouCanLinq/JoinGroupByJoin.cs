using LINQStudy.LinqToSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQStudy.ThinkYouCanLinq
{
    public class JoinGroupByJoin
    {
        public static void InnerJoin()
        {
            var products = ObjectLists.GetProducts();
            var categories = ObjectLists.GetCategories();

            var result = from c in categories
                         join p in products on c equals p.Category
                         select new { p.Category, ProductName = p.Name };

            foreach (var item in result)
            {
                Console.WriteLine(item.Category + ": " + item.ProductName);
            }
            Console.WriteLine();
        }


        public static void GroupJoin()
        {
            var products = ObjectLists.GetProducts();
            var categories = ObjectLists.GetCategories();

            var result = from c in categories
                         join p in products on c equals p.Category into ps
                         select new { Category = c, Products = ps };

            foreach (var item in result)
            {
                Console.WriteLine(item.Category);
                foreach (var p in item.Products)
                {
                    Console.WriteLine("\t" + p.Name);
                }
            }
            Console.WriteLine();
        }

        public static void ToLookup()
        {
            var products = ObjectLists.GetProducts();
            var categories = ObjectLists.GetCategories();

            var result = from c in categories
                         join p in products on c equals p.Category
                         select new { p.Category, ProductName = p.Name };

            // same as group join.
            var lookup = result.ToLookup(p => p.Category);

            //foreach (var item in lookup)
            //{
            //    //Console.WriteLine(lookup);
            //    //foreach (var p in lookup.)
            //    //{
            //    //    Console.WriteLine("\t" + p.Name);
            //    //}
            //}
            Console.WriteLine();
        }

        public static void LeftOuterJoin()
        {
            var products = ObjectLists.GetProducts();
            var categories = ObjectLists.GetCategories();

            var result = from c in categories
                         join p in products on c equals p.Category into ps
                         from p in ps.DefaultIfEmpty()
                         select new { Category = c, ProductName = p == null ? "No Product" : p.Name };

            foreach (var item in result)
            {
                Console.WriteLine(item.Category + ": " + item.ProductName);
                //Console.WriteLine(item.Category);
                //foreach (var p in item.Products)
                //{
                //    Console.WriteLine("\t" + p.Name);
                //}
            }
            Console.WriteLine();
        }
    }
}
