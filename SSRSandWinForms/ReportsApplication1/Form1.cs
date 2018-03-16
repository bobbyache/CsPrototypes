using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'SPC_DEV_H4CIDataSet.sp_BreachHistoryReport' table. You can move, or remove it, as needed.
            this.sp_BreachHistoryReportTableAdapter.Fill(this.SPC_DEV_H4CIDataSet.sp_BreachHistoryReport,
                DateTime.Parse("2018-01-01"),
                DateTime.Parse("2018-03-30"),
                1,
                3,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                false,
                false
                );
            this.reportViewer1.RefreshReport();

            LocalReport localReport = reportViewer1.LocalReport;
            byte[] data = localReport.Render("PDF");
            File.WriteAllBytes(@"C:\MyPDf.pdf", data);
        }
    }
}