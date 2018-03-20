using Microsoft.Reporting.WinForms;
using System.Data;
using System.Windows.Forms;

namespace SsrsViewer
{
    public partial class ReportViewer: UserControl, IReportRenderer
    {
        private LocalReport localReport;

        public ReportViewer()
        {
            InitializeComponent();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.localReport = reportViewer1.LocalReport;
        }

        public string ReportPath
        {
            get { return localReport.ReportPath; }
            set { this.localReport.ReportPath = value; }
        }
        
        public void AddDataSet(string dataSetName, DataTable dataTable)
        {
            localReport.DataSources.Add(new ReportDataSource(dataSetName, dataTable));
        }

        public virtual void Render()
        {
            reportViewer1.RefreshReport();
        }
    }
}
