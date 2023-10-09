using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using wf_DownloadManager.ThreadHandlers;

namespace wf_DownloadManager.Downloader
{
    class DownloadComplete
    {
        Control val_downloaded;
        Control val_progressPercentage;
        Form xform;
        public DownloadComplete(Form _form)
        {
            xform = _form;
            val_downloaded = xform.Controls.Find("val_downloaded", true).FirstOrDefault();
            val_progressPercentage = xform.Controls.Find("val_progressPercentage", true).FirstOrDefault();
        }
        public void eDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            xx_downloadCompleted(sender, e);
        }
        private void xx_downloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //if (Form1._cancellationTokenSource != null && 
            //    Form1._cancellationTokenSource.IsCancellationRequested)
            //    Form1._cancellationTokenSource?.Cancel();

            //TogglePauseThread.GetPauseEvent().Dispose();

            if (val_downloaded.InvokeRequired)
            {
                val_downloaded.Invoke(new MethodInvoker(() =>
                {
                    val_downloaded.Text = "Download Completed";
                }));
            }
            else
            {
                val_downloaded.Text = "Download Completed";
            }
        }
    }
}
