using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using wf_DownloadManager.Models;
using wf_DownloadManager.Utilities;

namespace wf_DownloadManager.UpdateUi
{
    internal class UpdateProgressBar
    {
        IInternet_Speed bandwidth = new Internet_Speed();
        public void Begin(
            ProgressBar progressBar,
            DownloadProgressChangedEventArgs e)
        {
            _updateProgressBar(progressBar, e);
        }
        private void _updateProgressBar(
            ProgressBar progressBar,
            DownloadProgressChangedEventArgs e)
        {
            if (progressBar.InvokeRequired)
                progressBar.Invoke(new MethodInvoker(() =>
                {
                    progressBar.Value = bandwidth.Bandwidth(e);
                }));
            else
                progressBar.Value = bandwidth.Bandwidth(e);
        }
    }
}
