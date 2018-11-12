using RuleEngine.Calculators.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Infrastructure.Calculators.Result
{
    public interface IInstrumentLikeListCountCalculator
    {
        IEnumerable<IdAndBooleanValueDataItem> InstrumentData { get; set; }
        IEnumerable<IdAndBooleanValueDataItem> LikeInstrumentData { get; set; }
        void Accept(ICalculatorVisitor visitor);
        decimal Calculate();
    }
}
