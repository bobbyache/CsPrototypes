using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQStudy.LinqToSql
{
    public class ObjectLists
    {
        public static string[] GetPresidents()
        {
            string[] presidents = {
            "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland",
            "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
            "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
            "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley",
            "Monroe", "Nixon", "Pierce", "Polk", "Reagan", "Roosevelt", "Taft",
            "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            return presidents;
        }

        public static IEnumerable<string> GetCategories()
        {
            return new string[]
            {
                "Beverages",
                "Vegetables",
                "Diary",
                "Seafood",
                "Meat",
                "Canned",
                "Bread"
            };
        }

        public static IEnumerable<Product> GetProducts()
        {
            return new Product[]
                {
            new Product { Name = "Coke", Category = "Beverages" },
            new Product { Name = "Pepsi", Category = "Beverages" },
            new Product { Name = "Kombucha", Category = "Beverages" },

            new Product { Name = "Potato", Category = "Vegetables" },
            new Product { Name = "Tomato", Category = "Vegetables" },
            new Product { Name = "Kale", Category = "Vegetables" },
            new Product { Name = "Spinach", Category = "Vegetables" },

            new Product { Name = "Milk", Category = "Dairy" },
            new Product { Name = "Kefir", Category = "Dairy" },
            new Product { Name = "Cheese", Category = "Dairy" },

            new Product { Name = "Salmon", Category = "Seafood" },
            new Product { Name = "Shrimp", Category = "Seafood" },
            new Product { Name = "Squid", Category = "Seafood" },

            new Product { Name = "Filet Mignon", Category = "Meat" },
            new Product { Name = "Bacon", Category = "Meat" },
            new Product { Name = "Sausage", Category = "Meat" },
            new Product { Name = "Steak", Category = "Meat" },
            new Product { Name = "Chicken Wings", Category = "Meat" },

            new Product { Name = "Whole Grain Bread", Category = "Bread" },
            };
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
