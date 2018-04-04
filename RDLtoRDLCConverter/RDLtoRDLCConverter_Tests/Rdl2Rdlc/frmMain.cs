using Rdl2RdlcConverter;
using System;
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

            if (!string.IsNullOrEmpty(lblSourceFolderPath.Text))
            {
                ChangeUiStatus(true);
                statusLabel.Text = "Converting...";

                var progress = new Progress<int>(percent => {
                    progressBar.Value = percent;
                });

                await Task.Run(() => {
                    RdlFolderConverter converter = new RdlFolderConverter();
                    converter.Convert(lblSourceFolderPath.Text, progress, lblTargetFolderPath.Text);
                    });

                ChangeUiStatus(false);
                statusLabel.Text = "Done...";
            }
        }

        private void btnSourceFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                lblSourceFolderPath.Text = dialog.SelectedPath;
                if (string.IsNullOrEmpty(lblTargetFolderPath.Text))
                    lblTargetFolderPath.Text = dialog.SelectedPath;

                btnConvert.Enabled = true;
            }
        }

        private void btnTargetFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                lblTargetFolderPath.Text = dialog.SelectedPath;
            }
        }

        private void ChangeUiStatus(bool busy)
        {
            btnConvert.Enabled = !busy;
            btnSourceFolder.Enabled = !busy;
            btnTargetFolder.Enabled = !busy;
            statusLabel.Text = (busy ? "Converting..." : "Done.");
        }
    }
}
