using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SsrsViewer
{
    public class AutoReport : IReportRenderer
    {
        private LocalReport localReport;

        public string ReportPath
        {
            get { return localReport.ReportPath; }
            protected set { this.localReport.ReportPath = value; }
        }

        public string OutputPath { get; protected set; }

        public string OutputType { get; protected set; }

        public AutoReport(string reportPath, string outputType, string outputPath)
        {
            localReport = new LocalReport();
            this.localReport.ReportPath = reportPath;
            OutputType = outputType;
            OutputPath = outputPath;
        }

        public void AddDataSet(string dataSetName, DataTable dataTable)
        {
            localReport.DataSources.Add(new ReportDataSource(dataSetName, dataTable));
        }

        public void Render()
        {
            byte[] data = localReport.Render(OutputType);
            File.WriteAllBytes(OutputPath, data);
        }
    }
}
