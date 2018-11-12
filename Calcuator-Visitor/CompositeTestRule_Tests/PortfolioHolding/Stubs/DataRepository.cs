using RuleEngine.Calculators.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.UnitTests.PortfolioHolding.Stubs
{
    public class DataRepository
    {
        public IEnumerable<PortfolioInstrumentDataItem> GetHeldInstrumentCountData()
        {
            IEnumerable<PortfolioInstrumentDataItem> benchMarkData = new List<PortfolioInstrumentDataItem>
                    {
                        new PortfolioInstrumentDataItem(368, 368),
                        new PortfolioInstrumentDataItem(507, 28)
                    };
            return benchMarkData;
        }

        public IEnumerable<IdAndDecimalValueDataItem> GetBenchMarkData()
        {
            IEnumerable<IdAndDecimalValueDataItem> benchMarkData = new List<IdAndDecimalValueDataItem>
                    {
                        new IdAndDecimalValueDataItem(368, 5.5M),
                        new IdAndDecimalValueDataItem(379, 4.5M),
                        new IdAndDecimalValueDataItem(324, 12.9M)
                    };
            return benchMarkData;
        }

        public IEnumerable<IdDataItem> GetPortfolioData()
        {
            IEnumerable<IdDataItem> instrumentDataList = new List<IdDataItem>()
                    {
                        new IdDataItem(368),
                        new IdDataItem(379)
                    };
            return instrumentDataList;
        }

        public IEnumerable<IdAndBooleanValueDataItem> GetInstrumentData()
        {
            IEnumerable<IdAndBooleanValueDataItem> instrumentDataList = new List<IdAndBooleanValueDataItem>()
                    {
                        new IdAndBooleanValueDataItem(368, false),
                        new IdAndBooleanValueDataItem(379, false)
                    };
            return instrumentDataList;
        }

        public IEnumerable<IdDataItem> GetIssuerData()
        {
            IEnumerable<IdDataItem> issuerDataList = new List<IdDataItem>()
                    {
                        new IdDataItem(368),
                        new IdDataItem(424),
                        new IdDataItem(324)
                    };
            return issuerDataList;
        }
    }
}
