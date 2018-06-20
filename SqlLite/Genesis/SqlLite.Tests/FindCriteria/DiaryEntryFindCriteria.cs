using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLite.Tests.FindCriteria
{
    public class DiaryEntryFindCriteria
    {
        public DiaryEntryFindCriteria(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
    }
}
