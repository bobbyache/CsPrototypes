using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototypes.Gui.Winforms.Input
{
    public partial class UserDetailsInputForm : UserControl
    {
        public event EventHandler UserDetailsSubmitted;

        public UserDetailsInputForm()
        {
            InitializeComponent();
        }

        public string FirstName
        {
            get { return this.txtFirstName.Text; }
            set { this.txtFirstName.Text = value; }
        }

        public string LastName
        {
            get { return this.txtLastName.Text; }
            set { this.txtLastName.Text = value; }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            UserDetailsSubmitted?.Invoke(this, new EventArgs());

            MessageBox.Show("Details submitted");
        }
    }
}
