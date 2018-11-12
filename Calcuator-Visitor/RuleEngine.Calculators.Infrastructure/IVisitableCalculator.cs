using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Infrastructure
{
    public interface IVisitableCalculator
    {
        void Accept(ICalculatorVisitor visitor);
    }
}
