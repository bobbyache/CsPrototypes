using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Infrastructure
{
    public interface ICalculator : IVisitableCalculator
    {
        int RuleId { get; }
        string AggregateName { get; }
        string ShortName { get; }
        decimal Calculate();
    }
}
