using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Data
{
    public class InstrumentData
    {
        public readonly int Id;
        public bool IsUnderlying;

        public InstrumentData(int id, bool isUnderlying)
        {
            this.Id = id;
            this.IsUnderlying = isUnderlying;
        }
    }
}
