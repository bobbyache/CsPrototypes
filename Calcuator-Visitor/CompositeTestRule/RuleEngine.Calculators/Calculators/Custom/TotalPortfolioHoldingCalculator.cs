using RuleEngine.Calculators.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using RuleEngine.Calculators.Infrastructure.Data;
using RuleEngine.Calculators.Infrastructure.Calculators.Custom;
using System;

namespace RuleEngine.Calculators.Custom
{
    public class TotalPortfolioHoldingCalculator : ICalculator, ITotalPortfolioHoldingCalculator
    {
        private ICalculatorVisitor visitor;

        public IEnumerable<IdAndBooleanValueDataItem> InstrumentDataList { get; set; }
        public IEnumerable<IdDataItem> PortfolioDataList { get; set; }
        public IEnumerable<PortfolioInstrumentDecimalDataItem> SourceData { get; set; }

        public string ShortName { get { return ""; } }

        public int RuleId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string AggregateName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Accept(ICalculatorVisitor visitor)
        {
            this.visitor = visitor;
        }

        public decimal Calculate()
        {
            if (visitor != null)
                visitor.Visit(this);

            var filteredRecs = SourceData.Where(src => PortfolioDataList.Any(ptf => ptf.Id == src.PorfolioId));
            return (decimal)filteredRecs.Sum(src => src.Value);
        }
    }
}
