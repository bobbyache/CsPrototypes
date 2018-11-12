using RuleEngine.Calculators.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Calculators.Aggregate
{
    public class SumCalculator : ICalculator
    {
        public string AggregateName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int RuleId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string ShortName { get { return ""; } }

        public void Accept(ICalculatorVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public decimal Calculate()
        {
            throw new NotImplementedException();
        }
    }
}
