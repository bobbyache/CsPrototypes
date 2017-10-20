using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class UserControlB : UserControl, IAsyncStateNotifiable
    {
        public UserControlB()
        {
            InitializeComponent();
        }

        public void StartWork(string identifier)
        {
            foreach (Control ctrl in this.Controls)
                ctrl.Enabled = false;
        }

        public void FinishWork(string identifier)
        {
            foreach (Control ctrl in this.Controls)
                ctrl.Enabled = true;
        }
    }
}
