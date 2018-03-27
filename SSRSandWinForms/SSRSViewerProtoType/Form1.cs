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
            LoadCombo();
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                var item = comboBox1.SelectedItem as IdItem;
                if (item != null)
                {
                    switch (item.Id)
                    {
                        case 1:
                            break;
                        case 2:
                            WeightVsLimitScheduleRepository repository = new WeightVsLimitScheduleRepository("server=ROB-LT;database=SPC_DEV_H4CI;Integrated Security=True;;Connection Reset=true;");
                            repository.Generate();

                            reportViewer1.ReportPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Reports\WeightVsLimitSchedule.rdlc");
                            reportViewer1.AddDataSet("WeightVsLimitSchedule", repository.Get());
                            
                            reportViewer1.Render();
                            break;
                    }
                }
            }
        }


        private void LoadCombo()
        {
            comboBox1.Items.AddRange(
                new IdItem[]
                {
                    new IdItem(1, "Breach History"),
                    new IdItem(2, "Weight Vs Limit Schedule")
                }
                );
        }
    }
}
