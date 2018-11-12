using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Calculators.Data
{
    public class BenchmarkData
    {
        public int Id { get; set; } /*ComponentId*/
        public decimal Weighting { get; set; } /*ComponentWeighting*/

        public BenchmarkData(int id, decimal weighting)
        {
            this.Id = id;
            this.Weighting = weighting;
        }
    }
}
