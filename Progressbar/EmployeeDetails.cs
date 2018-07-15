using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;

namespace Progressbar
{
    public partial class EmployeeDetails : Form
    {
        public EmployeeDetails()
        {
            InitializeComponent();
        }

        private void EmployeeDetails_Load(object sender, EventArgs e)
        {
            // Start the BackgroundWorker.
            bckgndwrkr.RunWorkerAsync();
        }

        private void bckgndwrkr_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                // Wait 100 milliseconds.
                Thread.Sleep(100);
                // Report progress.
                bckgndwrkr.ReportProgress(i);
            }
        }

        private void bckgndwrkr_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            progressBar1.Value = e.ProgressPercentage;
            // Set the text.
            this.Text = e.ProgressPercentage.ToString();
        }
    }
}
