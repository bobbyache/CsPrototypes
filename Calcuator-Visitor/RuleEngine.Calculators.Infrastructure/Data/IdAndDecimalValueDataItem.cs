using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Infrastructure.Data
{
    public class IdAndDecimalValueDataItem
    {
        public int Id { get; set; }
        public decimal Value { get; set; }

        public IdAndDecimalValueDataItem(int id, decimal value)
        {
            this.Id = id;
            this.Value = value;
        }
    }
}
