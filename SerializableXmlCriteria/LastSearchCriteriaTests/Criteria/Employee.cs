using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LastSearchCriteriaTests.Criteria
{
    
    public class Employee : Person
    {
        public Employee()
        {
        }

        [XmlAttribute]
        public double MonthlySalary { get; set; } = 0d;
        [XmlAttribute]
        public string EmployeeId { get; set; } = "EMP000";

        [XmlIgnore]
        public string Position { get; protected set; }
    }

    public class ChiefExecutiveOfficer : Employee
    {
        public ChiefExecutiveOfficer()
        {
            this.Position = "CEO";
        }
    }

    public class ChiefFinancialOfficer : Employee
    {
        public ChiefFinancialOfficer()
        {
            this.Position = "CFO";
        }
    }
}
