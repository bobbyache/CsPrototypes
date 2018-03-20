using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SsrsViewer
{
    public class CategorizedAutoReport : AutoReport
    {
        public ReportTypeEnum ReportType { get; private set; }

        public CategorizedAutoReport(ReportTypeEnum reportType, string outputType, string outputPath) : base(null, outputType, outputPath)
        {
            this.ReportType = reportType;
            this.ReportPath = GetReportPath(reportType);
        }

        private string GetReportPath(ReportTypeEnum reportType)
        {
            string name = ReportType.ToString();
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Reports",  $"{name}.rdlc");
        }
    }
}
