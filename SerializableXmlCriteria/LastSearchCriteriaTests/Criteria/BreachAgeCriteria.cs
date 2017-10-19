using LastSearchCriteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LastSearchCriteriaTests.Criteria
{
    public class BreachAgeCriteria : SerializableSectionedCriteria
    {
        private BreachAgeGeneralCriteriaSection generalCriteria = new BreachAgeGeneralCriteriaSection();

        public ComplianceSession Session
        {
            get { return generalCriteria.Session; }
            set { generalCriteria.Session = value; }
        }
        public int SessionId
        {
            get { return generalCriteria.SessionId; }
            set { generalCriteria.SessionId = value; }
        }

        public bool ShowBreachAges
        {
            get { return generalCriteria.ShowBreachAges; }
            set { generalCriteria.ShowBreachAges = value; }
        }

        public bool ShowOverriddenBreaches
        {
            get { return generalCriteria.ShowOverriddenBreaches; }
            set { generalCriteria.ShowOverriddenBreaches = value; }
        }

        public bool ShowRuleGroups
        {
            get { return generalCriteria.ShowRuleGroups; }
            set { generalCriteria.ShowRuleGroups = value; }
        }


        public BreachAgeCriteria(SectionedCriteriaSerializer criteriaSerializer) : base(criteriaSerializer) { }
        public BreachAgeCriteria(string xml, SectionedCriteriaSerializer criteriaSerializer) : base(xml, criteriaSerializer) { }

        protected override void DeserializeCriteriaSection(XElement rootElement)
        {
            generalCriteria = DeserializeSection<BreachAgeGeneralCriteriaSection>(rootElement);
        }

        protected override void SerializeCriteriaSections(XElement rootElement)
        {
            SerializeSection(generalCriteria, rootElement);
        }
    }
}
