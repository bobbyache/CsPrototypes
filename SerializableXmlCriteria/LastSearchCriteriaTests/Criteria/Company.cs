using LastSearchCriteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LastSearchCriteriaTests.Criteria
{
    public class Company : SerializableSectionedCriteria
    {
        public ChiefExecutiveOfficer CEO { get; set; }
        public ChiefFinancialOfficer CFO { get; set; }

        public Company(SectionedCriteriaSerializer criteriaSerializer) : base(criteriaSerializer) { }
        public Company(string xml, SectionedCriteriaSerializer criteriaSerializer) : base(xml, criteriaSerializer) { }

        protected override void DeserializeCriteriaSection(XElement rootElement)
        {
            CEO = DeserializeSection<ChiefExecutiveOfficer>(rootElement);
            CFO = DeserializeSection<ChiefFinancialOfficer>(rootElement);
        }

        protected override void SerializeCriteriaSections(XElement rootElement)
        {
            SerializeSection(CEO, rootElement);
            SerializeSection(CFO, rootElement);
        }
    }
}
