using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlexureTask
{
    public partial class AsyncForm : Form
    {

        // Declare a System.Threading.CancellationTokenSource.
        CancellationTokenSource cancelTokenSource;
        public AsyncForm()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {

            var asyncTask = new AsyncTask();
            txtResult.Clear();

            cancelTokenSource = new CancellationTokenSource();
            try
            {
                cancelTokenSource.CancelAfter(10000);

                var resultLength = await asyncTask.DownloadResourcesAsync(cancelTokenSource.Token);

                txtResult.Text  += "\r\nDownloads succeeded.\r\nThe result length is " + resultLength.ToString() + "\r\n";

            }
            catch (OperationCanceledException)
            {
                txtResult.Text += "\r\nDownloads canceled.\r\n";
            }
            catch (Exception)
            {
                txtResult.Text += "\r\nDownloads failed.\r\n";
            }

            cancelTokenSource = null;




        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (cancelTokenSource != null)
            {
                cancelTokenSource.Cancel();
            }

        }

      
    }
}
