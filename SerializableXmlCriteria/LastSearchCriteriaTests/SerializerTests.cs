using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.IO;
using LastSearchCriteria;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using LastSearchCriteriaTests.Criteria;

namespace LastSearchCriteriaTests
{
    [TestClass]
    public class SerializerTests
    {
        [TestMethod]
        public void CriteriaSection_CanBeSerializedAndDeserialized_Using_Serializer()
        {
            CriteriaSerializer serializer = new CriteriaSerializer();

            BreachAgeGeneralCriteriaSection criteria = new BreachAgeGeneralCriteriaSection
            {
                Session = ComplianceSession.New,
                SessionId = 2,
                ShowBreachAges = true,
                ShowOverriddenBreaches = true,
                ShowRuleGroups = false
            };

            string xml = serializer.Serialize<BreachAgeGeneralCriteriaSection>(criteria);
            BreachAgeGeneralCriteriaSection crit = serializer.Deserialize<BreachAgeGeneralCriteriaSection>(xml);

            Assert.AreEqual(CompactXml("<BreachAgeGeneralCriteriaSection session=\"New\" session-id=\"2\" show-breach-ages=\"true\" show-overridden-breaches=\"true\" show-rule-groups=\"false\" />"), CompactXml(xml));
        }

        [TestMethod]
        public void BreachAgeCriteria_WhenInstantiatedAndSerialized_Returns_SingleClosedXmlTag()
        {
            BreachAgeCriteria breachAgeCriteria = new BreachAgeCriteria(new SectionedCriteriaSerializer());
            breachAgeCriteria.Session = ComplianceSession.New;
            breachAgeCriteria.SessionId = 2;
            breachAgeCriteria.ShowBreachAges = true;
            breachAgeCriteria.ShowOverriddenBreaches = true;
            breachAgeCriteria.ShowRuleGroups = false;

            string expectedXml = CompactXml("<BreachAgeCriteria><BreachAgeGeneralCriteriaSection session=\"New\" session-id=\"2\" show-breach-ages=\"true\" show-overridden-breaches=\"true\" show-rule-groups=\"false\" /></BreachAgeCriteria>");
            string generatedXml = CompactXml(breachAgeCriteria.Serialize());

            Assert.AreEqual(expectedXml, generatedXml);
        }

        [TestMethod]
        public void BreachAgeCriteria_WhenInstantiated_ViaXml_Returns_Correct_Values()
        {
            string xml = "<BreachAgeCriteria><BreachAgeGeneralCriteriaSection session=\"New\" session-id=\"2\" show-breach-ages=\"true\" show-overridden-breaches=\"true\" show-rule-groups=\"false\" /></BreachAgeCriteria>";
            BreachAgeCriteria breachAgeCriteria = new BreachAgeCriteria(xml, new SectionedCriteriaSerializer());

            Assert.AreEqual(ComplianceSession.New, breachAgeCriteria.Session);
            Assert.AreEqual(2, breachAgeCriteria.SessionId);
            Assert.AreEqual(true, breachAgeCriteria.ShowBreachAges);
            Assert.AreEqual(true, breachAgeCriteria.ShowOverriddenBreaches);
            Assert.AreEqual(false, breachAgeCriteria.ShowRuleGroups);
        }

        [TestMethod]
        public void Company_WhenInstantiatedAndSerialized_Returns_CorrectXml()
        {
            Company company = new Company(new SectionedCriteriaSerializer());

            company.CEO = new ChiefExecutiveOfficer { DateOfBirth = DateTime.Parse("1972-01-01"), EmployeeId = "EMP003", FirstName = "Kobus", LastName = "Venter", MonthlySalary = 67000 };
            company.CFO = new ChiefFinancialOfficer { DateOfBirth = DateTime.Parse("1972-08-01"), EmployeeId = "EMP005", FirstName = "Michael", LastName = "Carter", MonthlySalary = 75000 };

            string xml = company.Serialize();

            Company newCompany = new Company(xml, new SectionedCriteriaSerializer());

            Assert.AreEqual(company.CFO.FirstName, newCompany.CFO.FirstName);
            Assert.AreEqual(company.CFO.LastName, newCompany.CFO.LastName);
            Assert.AreEqual(company.CFO.MonthlySalary, newCompany.CFO.MonthlySalary);
            Assert.AreEqual(company.CFO.Position, newCompany.CFO.Position);
            Assert.AreEqual(company.CFO.EmployeeId, newCompany.CFO.EmployeeId);
            Assert.AreEqual(company.CFO.DateOfBirth, newCompany.CFO.DateOfBirth);
            Assert.AreEqual(company.CFO.Age, newCompany.CFO.Age);

            Assert.AreEqual(company.CEO.FirstName, newCompany.CEO.FirstName);
            Assert.AreEqual(company.CEO.LastName, newCompany.CEO.LastName);
            Assert.AreEqual(company.CEO.MonthlySalary, newCompany.CEO.MonthlySalary);
            Assert.AreEqual(company.CEO.Position, newCompany.CEO.Position);
            Assert.AreEqual(company.CEO.EmployeeId, newCompany.CEO.EmployeeId);
            Assert.AreEqual(company.CEO.DateOfBirth, newCompany.CEO.DateOfBirth);
            Assert.AreEqual(company.CEO.Age, newCompany.CEO.Age);
        }

        private static string CompactXml(string xml)
        {
            return System.Text.RegularExpressions.Regex.Replace(xml, "[ \t\n\r\v\f]", "");
        }
    }
}
