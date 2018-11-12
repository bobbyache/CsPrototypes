using RuleEngine.Calculators.Infrastructure;
using RuleEngine.Calculators.Infrastructure.Calculators.Binary;
using RuleEngine.Calculators.Infrastructure.Calculators.Unary;
using System.Collections.Generic;
using RuleEngine.Calculators.Infrastructure.Data;
using RuleEngine.Calculators.Infrastructure.Calculators.Custom;
using System;
using RuleEngine.Data.Repositories;

namespace RuleEngine.Data
{
    public class CalculatorVisitor : ICalculatorVisitor
    {
        private string connectionString;

        public CalculatorVisitor(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Visit(IHeldIssuerCountCalculator calculator)
        {
            calculator.SourceData = new List<IdDataItem>();
        }

        public void Visit(IInstrumentInBenchmarkCalculator calculator)
        {
            calculator.ComponentInstruments = new List<IdAndBooleanValueDataItem>();
            calculator.ContextualInstruments = new List<IdAndBooleanValueDataItem>();
        }

        public void Visit(IPortfolioAttributeValueCalculator calculator)
        {
            ContextRepository contextRepository = new ContextRepository(this.connectionString);

            int[] allowedInstruments = contextRepository.GetAllowedInstrumentIds(calculator.RuleId);
            IEnumerable<Tuple<int, int>> instrumentPools = contextRepository.GetInstrumentPools(calculator.RuleId);

            IEnumerable<Tuple<int, int, int, int>> aggregateData = contextRepository.GetAggregateData("Issuer", instrumentPools);

            calculator.SetContext(instrumentPools, allowedInstruments);
            
            // ************ There is a method missing here !!! *************
            // Need to get the values as specified by the calculators... in this case it is
            // any specified attribute value such as "NAV". Now, with this, one can supply the 
            // aggregate and the data is prepared for calculation.

            calculator.SetAggregateData(aggregateData);
            #region Old Stuff
            //PortfolioAttributeRepository repository = new PortfolioAttributeRepository(this.connectionString);
            //int[] inContextInstrumentIds = new int[] { 234, 235, 236 };
            //decimal[] values = repository.GetNavAttributeValue(calculator.PortfolioIds);
            //calculator.SetValues(values);            
            #endregion
        }

        public void Visit(IHeldInstrumentCountCalculator calculator)
        {
            calculator.InstrumentContext = new List<IdAndBooleanValueDataItem>();
            calculator.PortfolioContext = new List<IdDataItem>();
            calculator.SourceData = new List<PortfolioInstrumentDataItem>();
        }

        public void Visit(ITotalPortfolioHoldingCalculator calculator) { }
        public void Visit(IBenchMarkCalculator calculator) { }
        public void Visit(IAdditionCalculator additionCalculator) { }
        public void Visit(ISingleValueCalculator singleValueCalculator) { }
        public void Visit(IInstrumentLikeListCountCalculator calculator) { }
        public void Visit(IPortfolioHoldingCalculator calculator) { }
    }
}
