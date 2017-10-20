using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    /*
     * D:\Sandbox\almsource\alm\dev\alm\sql\tables\account.py - This has paging example (see PagedSearch).

        See D:\Sandbox\almsource\alm\dev\alm\csharp\FE\ALMCommon\ALMCentral.cs to see how BackgroundWorker works...

        If any control that has registered an event has that event fired to tell the WorkingCoordinator that a long running process 
     * is about to start, the WorkingCoordinator must notify any controls that have an interest in that particular event. These 
     * controls will then know how to disable their own controls.
     */
    public partial class Form1 : Form
    {
        private BackgroundWorker backgroundWorker = new BackgroundWorker();
        private ControlStateNotificationCoordinator coordinator = new ControlStateNotificationCoordinator();

        public Form1()
        {
            InitializeComponent();
            backgroundWorker.DoWork +=new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);

            //coordinator.RegisterInterface(userControlA1);
            //coordinator.RegisterInterface(userControlB1);
            //coordinator.RegisterControl(button1);
            //coordinator.RegisterControl(button2);
            //coordinator.RegisterControl(button3, new AsyncWorkingControlBehaviour { VisibleWhenWorking = false, VisibleWhenComplete = true, EnabledWhenComplete = true } );
            ////coordinator.UnregisterControl(button1);

            //OperationNotifier.

            //OperationNotifier.RegisterOperation("SearchDeposits");
            //OperationNotifier.RegisterOperation("SearchInvestments");
            OperationNotifier.Register("SearchDeposits", userControlA1);
            OperationNotifier.Register("SearchInvestments", userControlB1);


            //OperationNotifier.

            //OperationNotifier.UnregisterOperation("SearchDeposits");
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //coordinator.FinishWork();
            //OperationNotifier.FinishWork("SearchDeposits");
            OperationNotifier.FinishAllWork();
        }

        private void  backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DoLongRunningFunction();
        }

        private void menu1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //coordinator.StartWork();
            OperationNotifier.StartWork("SearchDeposits");
            backgroundWorker.RunWorkerAsync();
        }

        private void menu2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //coordinator.StartWork();
            OperationNotifier.StartWork("SearchInvestments");
            backgroundWorker.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //coordinator.StartWork();
            OperationNotifier.StartWork("SearchDeposits");
            backgroundWorker.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OperationNotifier.StartWork("SearchInvestments");
            //coordinator.StartWork();
            backgroundWorker.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //coordinator.StartWork();
            backgroundWorker.RunWorkerAsync();
        }

        private void DoLongRunningFunction()
        {
            Thread.Sleep(4000);
        }
    }
}
