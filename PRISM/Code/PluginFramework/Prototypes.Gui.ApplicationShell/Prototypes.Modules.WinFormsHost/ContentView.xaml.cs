﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prototypes.Modules.WinFormsHost
{
    /// <summary>
    /// Interaction logic for WinformsHostView.xaml
    /// </summary>
    public partial class ContentView : UserControl
    {
        public ContentView()
        {
            InitializeComponent();
        }

        private void InputForm_UserDetailsSubmitted(object sender, EventArgs e)
        {
            MessageBox.Show($"Message from WPF: {InputForm.LastName},  {InputForm.FirstName}");
        }
    }
}
