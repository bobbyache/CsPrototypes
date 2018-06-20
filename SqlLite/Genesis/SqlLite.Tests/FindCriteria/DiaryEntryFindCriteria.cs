using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLite.Tests.FindCriteria
{
    public class DiaryEntryFindCriteria
    {
        public DiaryEntryFindCriteria(string title = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            this.Title = title;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public string Title { get; }
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }
    }
}
