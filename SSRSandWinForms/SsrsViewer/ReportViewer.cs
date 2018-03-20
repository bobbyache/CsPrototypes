using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Reflection;
using System.IO;
using System.Data.SqlClient;
using SsrsViewer.Repositories;

namespace SsrsViewer
{
    public partial class ReportViewer: UserControl
    {
        public ReportViewer()
        {
            InitializeComponent();
        }

      

        public void LoadReport()
        {

            // ***************************************************************************
            //BreachHistoryReportRepository repository = new BreachHistoryReportRepository("server=ROB-LT;database=SPC_DEV_H4CI;Integrated Security=True;;Connection Reset=true;");
            //repository.Generate();

            WeightVsLimitScheduleRepository repository = new WeightVsLimitScheduleRepository("server=ROB-LT;database=SPC_DEV_H4CI;Integrated Security=True;;Connection Reset=true;");
            repository.Generate();

            // ***************************************************************************
            // Using the Report Viewer...
            // ***************************************************************************
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport viewerReport = reportViewer1.LocalReport;
            viewerReport.ReportPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Reports\WeightVsLimitSchedule.rdlc");
            viewerReport.DataSources.Add(new ReportDataSource("WeightVsLimitScheduleDataSet", repository.Get()));

            reportViewer1.RefreshReport();
            // ***************************************************************************


            // ***************************************************************************
            // Using the Exporting Results
            // ***************************************************************************
            LocalReport exportReport = new LocalReport();
            exportReport.ReportPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Reports\WeightVsLimitSchedule.rdlc");
            exportReport.DataSources.Add(new ReportDataSource("WeightVsLimitScheduleDataSet", repository.Get()));
            byte[] data = exportReport.Render("PDF");
            File.WriteAllBytes(@"C:\WeightVsLimitScheduleDataSet.pdf", data);
            // ***************************************************************************
        }
    }
}
