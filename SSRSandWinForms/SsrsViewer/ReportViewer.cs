using Microsoft.Reporting.WinForms;
using System.Data;
using System.Windows.Forms;

namespace SsrsViewer
{
    public partial class ReportViewer: UserControl
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

        public void Render()
        {
            reportViewer1.RefreshReport();
        }


        //public void LoadReport()
        //{

        //    // ***************************************************************************
        //    //BreachHistoryReportRepository repository = new BreachHistoryReportRepository("server=ROB-LT;database=SPC_DEV_H4CI;Integrated Security=True;;Connection Reset=true;");
        //    //repository.Generate();

        //    WeightVsLimitScheduleRepository repository = new WeightVsLimitScheduleRepository("server=ROB-LT;database=SPC_DEV_H4CI;Integrated Security=True;;Connection Reset=true;");
        //    repository.Generate();

        //    // ***************************************************************************
        //    // Using the Report Viewer...
        //    // ***************************************************************************
        //    reportViewer1.ProcessingMode = ProcessingMode.Local;
        //    LocalReport viewerReport = reportViewer1.LocalReport;
        //    viewerReport.ReportPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Reports\WeightVsLimitSchedule.rdlc");
        //    viewerReport.DataSources.Add(new ReportDataSource("WeightVsLimitScheduleDataSet", repository.Get()));

        //    reportViewer1.RefreshReport();
        //    // ***************************************************************************


        //    // ***************************************************************************
        //    // Using the Exporting Results
        //    // ***************************************************************************
        //    LocalReport exportReport = new LocalReport();
        //    exportReport.ReportPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Reports\WeightVsLimitSchedule.rdlc");
        //    exportReport.DataSources.Add(new ReportDataSource("WeightVsLimitScheduleDataSet", repository.Get()));
        //    byte[] data = exportReport.Render("PDF");
        //    File.WriteAllBytes(@"C:\WeightVsLimitScheduleDataSet.pdf", data);
        //    // ***************************************************************************
        //}
    }
}
