using RuleEngine.Calculators.Binary;
using RuleEngine.Calculators.Calculators.Unary;
using System.Collections.Generic;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.Calculators.Infrastructure.Calculators.Binary;
using RuleEngine.Calculators.Infrastructure.Calculators.Unary;
using System;
using RuleEngine.Calculators.Custom;
using RuleEngine.Calculators.Calculators.Base;
using System.Xml.Linq;
using RuleEngine.Calculators.Calculators;
using RuleEngine.Calculators.Calculators.Custom;

namespace RuleEngine.Calculators
{
    public class RuleCalculatorFactory
    {
        private CalculatorMapper mapper = new CalculatorMapper();

        public ICalculator CreateRuleCalculator(string xml, ICalculatorVisitor calculatorVisitor)
        {
            ICalculator calculator = this.CreateResultCalculator(xml);
            calculator.Accept(calculatorVisitor);

            return calculator;
        }

        private ICalculator CreateResultCalculator(string xml)
        {
            XElement element = XElement.Parse(xml);
            XElement resultCalcElement = element.Element("ResultCalculator");
            string shortName = (string)resultCalcElement.Attribute("short-name").Value;

            BaseCalculator resultCalculator = mapper.Create(shortName);

            if (resultCalcElement != null)
                AddCalculators(resultCalculator, resultCalcElement);

            return resultCalculator;
        }

        private void AddCalculators(BaseCalculator calculator, XElement calculatorElement)
        {
            IEnumerable<XElement> elements = calculatorElement.Elements();

            foreach (XElement element in elements)
            {
                string shortName = (string)element.Attribute("short-name").Value;
                BaseCalculator childCalculator = mapper.Create(shortName);
                calculator.AddCalculator(childCalculator);
                AddCalculators(childCalculator, element);
            }
        }
    }
}
