using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Infrastructure.Calculators.Custom
{
    public interface IPortfolioAttributeValueCalculator : ICalculator
    {
        Tuple<int, int>[] InstrumentPools { get; }
        Tuple<int, int, int, int>[] AggregateData { get; }

        Tuple<int, int, int>[] Answers { get; }

        void SetValues(decimal[] values);

        void SetAggregateData(IEnumerable<Tuple<int, int, int, int>> aggregateData);

        void SetContext(IEnumerable<Tuple<int, int>> instrumentIdPools, int[] allowedInstrumentids);
    }
}
