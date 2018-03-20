using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SsrsViewer
{
    public class CategorizedReportViewer : ReportViewer
    {
        private ReportTypeEnum reportType;
        public ReportTypeEnum ReportType
        {
            get { return reportType; }
            set
            {
                this.reportType = value;
                base.ReportPath = GetReportPath(reportType);
            }
        }
        private string GetReportPath(ReportTypeEnum reportType)
        {
            string name = ReportType.ToString();
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Reports", $"{name}.rdlc");
        }

        public override void Render()
        {
            if (this.ReportPath != null)
                base.Render();
            else
                throw new Exception("ReportViewer does not contain enough information to process the report request. Check the report path.");
        }
    }
}
