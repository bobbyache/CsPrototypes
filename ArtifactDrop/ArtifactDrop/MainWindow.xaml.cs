using System;
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

namespace ArtifactDrop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Topmost = true;
            this.Activated += MainWindow_Activated;
            this.MouseDown += MainWindow_MouseDown;
            this.MouseDoubleClick += MainWindow_MouseDoubleClick;
            this.PreviewDragOver += MainWindow_PreviewDragOver;
            //this.Drop += MainWindow_Drop;

        }

        private void MainWindow_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
            //throw new NotImplementedException();
        }

        private void MainWindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Here you go!");
        }

        // Draw your own target: https://jeremybytes.blogspot.co.za/2009/03/wpf-xaml-sample.html
        // TaskBar Stuff (This Library - see Nuget - and comprehensive tutorial at https://www.codeproject.com/Articles/36468/WPF-NotifyIcon)

        private void Image_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Assuming you have one file that you care about, pass it off to whatever
                // handling code you have defined.
                HandleFileOpen(files);
            }
        }

        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
            else
            {
                ContextMenu cm = this.FindResource("contextMenu") as ContextMenu;
                cm.PlacementTarget = sender as Window;
                cm.IsOpen = true;
            }
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            this.Topmost = true;
            this.Activate();
        }

        private void HandleFileOpen(string[] files)
        {
            MessageBox.Show(string.Join(Environment.NewLine, files));
        }

        private void Image_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
