using RuleEngine.Calculators.Calculators.Base;
using RuleEngine.Calculators.Infrastructure;
using RuleEngine.Calculators.Infrastructure.Calculators.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Calculators.Custom
{
    public class PortfolioAttributeValueCalculator : BaseCalculator, IPortfolioAttributeValueCalculator
    { 
        public PortfolioAttributeValueCalculator(string shortName) : base(shortName)
        {
            // In actual fact, we could provide a "portfolio context" visitor for this if necessary,
            // but here, just hard code it.
            //this.PortfolioIds = new int[] { 347 };
        }

        private decimal[] values;

        public Tuple<int, int>[] InstrumentPools { get; private set; }
        public Tuple<int, int, int, int>[] AggregateData { get; private set; }

        public Tuple<int, int, int>[] Answers { get; private set; }

        public override decimal Calculate()
        {
            if (visitor != null)
                visitor.Visit(this);

            Answers = (from t in AggregateData
                        group t by new { t.Item1, t.Item3 }
                        into grp
                        select new Tuple<int, int, int>(grp.Key.Item1, grp.Key.Item3, grp.Sum(t => t.Item4))).ToArray();


            //this.Answers = AggregateData.GroupBy(x => new { x.Item1, x.Item3 })
            //    into grp select new
                //.Select(cl => new Tuple<int, int, int>(cl. cl.Sum(c => c.Item4))).ToArray();

            return 0;
            //return AggregateData.GroupBy(agg => agg.Item3)
            //    .Select(cl => new Tuple<int, int, int>(cl.Sum(c => c.Item4)))
        }

        public void SetValues(decimal[] values)
        {
            this.values = values;
        }

        public void SetContext(IEnumerable<Tuple<int, int>> instrumentIdPools, int[] allowedInstrumentids)
        {
            this.InstrumentPools =
                instrumentIdPools.Where(pool => allowedInstrumentids.Any(inst => inst == pool.Item2)).ToArray();
        }

        public void SetAggregateData(IEnumerable<Tuple<int, int, int, int>> aggregateData)
        {
            this.AggregateData = aggregateData.ToArray();
        }
    }
}
