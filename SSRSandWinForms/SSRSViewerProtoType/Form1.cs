using SSRSViewerPrototType.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSRSViewerProtoType
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            WeightVsLimitScheduleRepository repository = new WeightVsLimitScheduleRepository("server=ROB-LT;database=SPC_DEV_H4CI;Integrated Security=True;;Connection Reset=true;");
            repository.Generate();

            //reportViewer1.LoadReport();\
            reportViewer1.ReportPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Reports\WeightVsLimitSchedule.rdlc");
            reportViewer1.AddDataSet("WeightVsLimitScheduleDataSet", repository.Get());

            reportViewer1.Render();
        }
    }
}
