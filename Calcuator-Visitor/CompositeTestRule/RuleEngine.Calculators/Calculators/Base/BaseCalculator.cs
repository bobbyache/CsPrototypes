using RuleEngine.Calculators.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Calculators.Base
{
    public abstract class BaseCalculator: ICalculator
    {
        protected ICalculatorVisitor visitor;
        private List<BaseCalculator> calculators = new List<BaseCalculator>();

        public BaseCalculator(string shortName)
        {
            this.ShortName = shortName;
        }

        public string AggregateName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int RuleId { get; }

        public string ShortName { get; private set; }


        internal BaseCalculator[] Calculators { get { return calculators.ToArray(); } }

        public void Accept(ICalculatorVisitor visitor)
        {
            this.visitor = visitor;
            foreach (BaseCalculator calculator in calculators)
                calculator.Accept(visitor);
        }

        public abstract decimal Calculate();

        internal void AddCalculator(BaseCalculator calculator)
        {
            calculators.Add(calculator);
        }
    }
}
