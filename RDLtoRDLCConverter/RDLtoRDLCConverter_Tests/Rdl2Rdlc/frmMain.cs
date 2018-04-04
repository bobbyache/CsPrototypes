using Rdl2RdlcConverter;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rdl2Rdlc
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            statusLabel.Text = "Idle";
            progressBar.Maximum = 100;
            btnConvert.Enabled = false;
        }

        private async void btnConvert_Click(object sender, EventArgs e)
        {
            // http://blog.stephencleary.com/2012/02/reporting-progress-from-async-tasks.html

            if (!string.IsNullOrEmpty(lblFolderPath.Text))
            {
                btnConvert.Enabled = false;
                statusLabel.Text = "Converting...";

                var progress = new Progress<int>(percent => {
                    progressBar.Value = percent;
                });

                await Task.Run(() => {
                    RdlFolderConverter converter = new RdlFolderConverter();
                    converter.Convert(lblFolderPath.Text, progress);
                    });

                btnConvert.Enabled = true;
                statusLabel.Text = "Done...";
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                lblFolderPath.Text = dialog.SelectedPath;
                btnConvert.Enabled = true;
            }
        }
    }
}
