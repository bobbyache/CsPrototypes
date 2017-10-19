using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LastSearchCriteriaTests.Criteria
{
    public class Person

    {
        [XmlAttribute]
        public string FirstName { get; set; } = "John";
        [XmlAttribute]
        public string LastName { get; set; } = "Doe";
        [XmlAttribute]
        public DateTime DateOfBirth { get; set; }

        [XmlIgnore]
        public int Age
        {
            get
            {
                int days = (DateTime.Today - DateOfBirth).Days;
                //assume 365.25 days per year
                decimal years = days / 365.25m;

                return (int)years;
            }
        }
    }
}
