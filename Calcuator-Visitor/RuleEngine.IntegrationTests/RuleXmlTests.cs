
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngine.Calculators.Infrastructure;
using System.Collections.Generic;
using System.Xml.Linq;
using System;
using RuleEngine.Calculators.Calculators.Base;
using RuleEngine.Calculators;

namespace RuleEngine.IntegrationTests
{
    [TestClass]
    public class RuleXmlTests
    {
        [TestMethod]
        [TestCategory("RuleXml")]
        [DeploymentItem(@"RuleXml\RuleA.xml")]
        public void Calculator_Create_Returns_Correct_Calculator()
        {
            string ruleXml = System.IO.File.ReadAllText(@"RuleA.xml");
            Calculator calculator = CalculatorFactory.Create(ruleXml);

            Assert.AreEqual("percentage", calculator.ShortName);
        }

        [TestMethod]
        [TestCategory("RuleXml")]
        [DeploymentItem(@"RuleXml\RuleA.xml")]
        public void Calculator_Create_Creates_And_Assigns_A_Single_ChildCalculator()
        {
            string ruleXml = System.IO.File.ReadAllText(@"RuleA.xml");
            Calculator calculator = CalculatorFactory.Create(ruleXml);

            Assert.AreEqual("plus", calculator.Calculators[0].ShortName);
        }

        [TestMethod]
        [TestCategory("RuleXml")]
        [DeploymentItem(@"RuleXml\RuleA.xml")]
        public void Calculator_Create_Creates_And_Assigns_A_Single_ChildCalculator_WithTwoChildCalculators()
        {
            string ruleXml = System.IO.File.ReadAllText(@"RuleA.xml");
            Calculator calculator = CalculatorFactory.Create(ruleXml);

            Assert.AreEqual("portfolioholdingwithcontext", calculator.Calculators[0].Calculators[0].ShortName);
            Assert.AreEqual("portfolioholdingwithcontext", calculator.Calculators[0].Calculators[1].ShortName);
        }

        [TestMethod]
        [TestCategory("RuleXml")]
        [DeploymentItem(@"RuleXml\RuleA.xml")]
        public void Calculator2_Create_Creates_And_Returns_Correct_Calculator()
        {
            string ruleXml = System.IO.File.ReadAllText(@"RuleA.xml");

            RuleCalculatorFactory factory = new RuleCalculatorFactory();
            ICalculator calculator = factory.CreateRuleCalculator(ruleXml, null);

            Assert.AreEqual("percentage", calculator.ShortName);
        }

        [TestMethod]
        [TestCategory("RuleXml")]
        [DeploymentItem(@"RuleXml\RuleA.xml")]
        public void Calculator2_Create_Creates_And_Assigns_A_Single_ChildCalculator()
        {
            string ruleXml = System.IO.File.ReadAllText(@"RuleA.xml");

            RuleCalculatorFactory factory = new RuleCalculatorFactory();
            ICalculator calculator = factory.CreateRuleCalculator(ruleXml, null);
            ICalculator firstChildCalculator = ((BaseCalculator)calculator).Calculators[0];

            Assert.AreEqual("plus", firstChildCalculator.ShortName);
        }

        [TestMethod]
        [TestCategory("RuleXml")]
        [DeploymentItem(@"RuleXml\RuleA.xml")]
        public void Calculator2_Create_Creates_And_Assigns_A_Single_ChildCalculator_WithTwoChildCalculators()
        {
            string ruleXml = System.IO.File.ReadAllText(@"RuleA.xml");

            RuleCalculatorFactory factory = new RuleCalculatorFactory();
            ICalculator calculator = factory.CreateRuleCalculator(ruleXml, null);

            BaseCalculator[] targetCalculators = GetChildrenOfFirstChildOf(calculator);

            Assert.AreEqual("portfolioholdingwithcontext", targetCalculators[0].ShortName);
            Assert.AreEqual("portfolioholdingwithcontext", targetCalculators[1].ShortName);
        }

        private BaseCalculator[] GetChildrenOfFirstChildOf(ICalculator calculator)
        {
            BaseCalculator currentCalculator = (BaseCalculator)calculator;
            BaseCalculator immediateChildCalculator = (BaseCalculator)currentCalculator.Calculators[0];
            BaseCalculator[] targetCalculators = immediateChildCalculator.Calculators;

            return targetCalculators;
        }
    }

    public class CalculatorFactory
    {
        public static Calculator Create(string xml)
        {
            XElement element = XElement.Parse(xml);
            XElement resultCalcElement = element.Element("ResultCalculator");

            Calculator resultCalculator = new Calculator((string)resultCalcElement.Attribute("short-name").Value);

            if (resultCalcElement != null)
            {
                AddCalculators(resultCalculator, resultCalcElement);
            }

            return resultCalculator;
        }

        private static void AddCalculators(Calculator calculator, XElement calculatorElement)
        {
            IEnumerable<XElement> elements = calculatorElement.Elements();

            foreach (XElement element in elements)
            {
                Calculator childCalculator = new Calculator((string)element.Attribute("short-name").Value);
                calculator.AddCalculator(childCalculator);
                AddCalculators(childCalculator, element);
            }
        }
    }

    public class Calculator : BaseCalculator
    {
        public Calculator(string shortName):base(shortName)
        {
                
        }

        public override decimal Calculate()
        {
            throw new NotImplementedException();
        }
    }
}
