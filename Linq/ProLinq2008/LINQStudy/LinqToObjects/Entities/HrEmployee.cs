using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQStudy.LinqToObjects.Entities
{
    public class HrEmployee
    {
        public static List<HrEmployee> HrEmployees()
        {
            List<HrEmployee> empList = new List<HrEmployee>();
            empList.Add(new HrEmployee()
            {
                ID = 1,
                FName = "John",
                MName = "",
                LName = "Shields",
                DOB = DateTime.Parse("12/11/1971"),
                Sex = 'M'
            });
            empList.Add(new HrEmployee()
            {
                ID = 2,
                FName = "Mary",
                MName = "Matthew",
                LName = "Jacobs",
                DOB = DateTime.Parse("1/9/1961"),
                Sex = 'F'
            });
            empList.Add(new HrEmployee()
            {
                ID = 3,
                FName = "Amber",
                MName = "Carl",
                LName = "Agar",
                DOB = DateTime.Parse("12/3/1971"),
                Sex = 'M'
            });
            empList.Add(new HrEmployee()
            {
                ID = 4,
                FName = "Kathy",
                MName = "",
                LName = "Berry",
                DOB = DateTime.Parse("11/5/1976"),
                Sex = 'F'
            });
            empList.Add(new HrEmployee()
            {
                ID = 5,
                FName = "Lena",
                MName = "Ashco",
                LName = "Bilton",
                DOB = DateTime.Parse("5/6/1978"),
                Sex = 'F'
            });
            empList.Add(new HrEmployee()
            {
                ID = 6,
                FName = "Susanne",
                MName = "",
                LName = "Buck",
                DOB = DateTime.Parse("3/7/1965"),
                Sex = 'F'
            });
            empList.Add(new HrEmployee()
            {
                ID = 7,
                FName = "Jim",
                MName = "",
                LName = "Brown",
                DOB = DateTime.Parse("9/11/1972"),
                Sex = 'M'
            });
            empList.Add(new HrEmployee()
            {
                ID = 8,
                FName = "Jane",
                MName = "G",
                LName = "Hooks",
                DOB = DateTime.Parse("12/11/1972"),
                Sex = 'F'
            });
            empList.Add(new HrEmployee()
            {
                ID = 9,
                FName = "Robert",
                MName = "",
                LName = "",
                DOB = DateTime.Parse("6/5/1964"),
                Sex = 'M'
            });
            empList.Add(new HrEmployee()
            {
                ID = 10,
                FName = "Cindy",
                MName = "Preston",
                LName = "Fox",
                DOB = DateTime.Parse("1/11/1978"),
                Sex = 'M'
            });

            return empList;
        }

        public int ID { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public DateTime DOB { get; set; }
        public char Sex { get; set; } 

    }
}
