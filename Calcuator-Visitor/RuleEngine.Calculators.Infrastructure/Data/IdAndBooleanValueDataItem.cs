using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Infrastructure.Data
{
    public class IdAndBooleanValueDataItem
    {
        public int Id { get; set; }
        public bool Value { get; set; }

        public IdAndBooleanValueDataItem(int id, bool value)
        {
            this.Id = id;
            this.Value = value;
        }
    }
}
