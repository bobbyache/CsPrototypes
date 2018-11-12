using RuleEngine.Calculators.Infrastructure;
using System;
using RuleEngine.Calculators.Infrastructure.Calculators.Binary;
using RuleEngine.Calculators.Infrastructure.Calculators.Unary;
using RuleEngine.Calculators.Infrastructure.Calculators.Custom;

namespace RuleEngine.UnitTests.PortfolioHolding.Stubs
{
    public enum StubVisitorAggregateOption
    {
        Instrument,
        Issuer
    }

    public class StubCalculatorVisitor : ICalculatorVisitor
    {
        private const string CalculatorMustBeDefined = "Calculator must be supplied as a parameter.";
        private StubVisitorAggregateOption aggregateOption;
        private DataRepository repository = new DataRepository();

        public StubCalculatorVisitor(StubVisitorAggregateOption aggregateOption = StubVisitorAggregateOption.Instrument)
        {
            this.aggregateOption = aggregateOption;
        }

        public void Visit(IInstrumentInBenchmarkCalculator calculator)
        {
            //calculator.ContextualInstruments = repository.Get
        }

        public void Visit(ITotalPortfolioHoldingCalculator calculator)
        {
            //throw new NotImplementedException();
        }

        public void Visit(IPortfolioAttributeValueCalculator calculator)
        {
            throw new NotImplementedException();
        }

        public void Visit(IInstrumentLikeListCountCalculator calculator)
        {
            //throw new NotImplementedException();
        }

        public void Visit(IPortfolioHoldingCalculator calculator)
        {
            if (calculator == null)
                throw new ArgumentNullException(CalculatorMustBeDefined);

            calculator.InstrumentDataList = repository.GetInstrumentData();
            calculator.PortfolioDataList = repository.GetPortfolioData();
            //calculator.SourceData = repository.Get
        }

        public void Visit(IBenchMarkCalculator calculator)
        {
            if (calculator == null)
                throw new ArgumentNullException(CalculatorMustBeDefined);

            calculator.BenchMarkData = repository.GetBenchMarkData();

            if (aggregateOption == StubVisitorAggregateOption.Instrument)
                calculator.InstrumentContext = repository.GetInstrumentData();
            else
                calculator.IssuerContext = repository.GetIssuerData();
        }

        public void Visit(IHeldIssuerCountCalculator calculator)
        {
            if (calculator == null)
                throw new ArgumentNullException(CalculatorMustBeDefined);

            calculator.SourceData = repository.GetIssuerData();
        }

        public void Visit(IHeldInstrumentCountCalculator calculator)
        {
            if (calculator == null)
                throw new ArgumentNullException(CalculatorMustBeDefined);

            calculator.InstrumentContext = repository.GetInstrumentData();
            calculator.PortfolioContext = repository.GetPortfolioData();
            calculator.SourceData = repository.GetHeldInstrumentCountData();
        }

        public void Visit(ISingleValueCalculator calculator)
        {
            if (calculator == null)
                throw new ArgumentNullException(CalculatorMustBeDefined);
        }

        public void Visit(IAdditionCalculator calculator)
        {
            if (calculator == null)
                throw new ArgumentNullException(CalculatorMustBeDefined);
        }
    }
}
