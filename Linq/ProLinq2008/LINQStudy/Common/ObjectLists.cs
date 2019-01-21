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
    }
}
