using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngine.Calculators;
using RuleEngine.Data;
using RuleEngine.Calculators.Infrastructure;
using System.IO;

namespace RuleEngine.IntegrationTests
{
    [TestClass]
    public class Rule13Tests
    {
        [TestMethod]
        [TestCategory("Rule13")]
        [DeploymentItem(@"RuleXml\Rule13.xml")]
        public void Rule13_When_Processed_ReturnsSaveValue_As_CurrentProcess()
        {
            string ruleXml = File.ReadAllText(@"Rule13.xml");

            RuleCalculatorFactory factory = new RuleCalculatorFactory();
            ICalculator calculator = factory.CreateRuleCalculator(ruleXml, new CalculatorVisitor(Constants.ConnectionString));
            decimal value =  calculator.Calculate();

            Assert.IsTrue(value > 0);
        }
    }
}
