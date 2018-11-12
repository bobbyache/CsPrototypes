using RuleEngine.Calculators.Infrastructure.Calculators.Binary;
using RuleEngine.Calculators.Infrastructure.Calculators.Custom;
using RuleEngine.Calculators.Infrastructure.Calculators.Unary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Infrastructure
{
    public interface ICalculatorVisitor
    {
        void Visit(IAdditionCalculator calculator);
        void Visit(ISingleValueCalculator calculator);
        void Visit(IBenchMarkCalculator calculator);
        void Visit(IHeldInstrumentCountCalculator calculator);
        void Visit(IHeldIssuerCountCalculator calculator);
        void Visit(IPortfolioHoldingCalculator calculator);
        void Visit(IInstrumentInBenchmarkCalculator calculator);
        void Visit(IInstrumentLikeListCountCalculator calculator);
        void Visit(ITotalPortfolioHoldingCalculator calculator);

        void Visit(IPortfolioAttributeValueCalculator calculator);
        
    }
}
