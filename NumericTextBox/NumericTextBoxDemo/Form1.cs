using System;
using System.Windows.Forms;
using NumericTextboxControl;

namespace NumericTextBoxDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void updateLabel_KeyRejected(object sender, NumericTextBox.KeyRejectedEventArgs e)
        {
            lblEventArgs.Text = DateTime.Now.ToString("HH:mm:ss") + " " + e.ToString();
        }

        private void updateLabel_PasteRejected(object sender, NumericTextBox.PasteEventArgs e)
        {
            lblEventArgs.Text = DateTime.Now.ToString("HH:mm:ss") + " " + e.ToString();
        }
    }
}
