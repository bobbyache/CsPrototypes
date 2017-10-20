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
    public partial class UserControlA : UserControl, IAsyncStateNotifiable
    {
        public UserControlA()
        {
            InitializeComponent();
        }

        public void StartWork(string operationIdentifier)
        {
            foreach (Control ctrl in this.Controls)
                ctrl.Enabled = false;
        }

        public void FinishWork(string operationIdentifer)
        {
            foreach (Control ctrl in this.Controls)
                ctrl.Enabled = true;
        }
    }
}
