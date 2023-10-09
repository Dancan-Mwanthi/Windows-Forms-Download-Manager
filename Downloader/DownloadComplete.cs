using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using wf_DownloadManager.Models;
using wf_DownloadManager.ThreadHandlers;

namespace wf_DownloadManager.Downloader
{
    class DownloadComplete
    {
        Form xform;
        public DownloadComplete(Form _form)
        {
            xform = _form;
            //val_downloaded = xform.Controls.Find("val_downloaded", true).FirstOrDefault();
            //val_progressPercentage = xform.Controls.Find("val_progressPercentage", true).FirstOrDefault();
        }
        public void eDownloadComplete(object sender, 
                                    AsyncCompletedEventArgs e, 
                                    ControlsModel controlsModel)
        {
            xx_downloadCompleted(sender, e, controlsModel);
        }
        private void xx_downloadCompleted(object sender, 
                                        AsyncCompletedEventArgs e, 
                                        ControlsModel controlsModel)
        {
            if (Form1._cancellationTokenSource != null &&
                Form1._cancellationTokenSource.IsCancellationRequested)
                Form1._cancellationTokenSource?.Cancel();

            //TogglePauseThread.GetPauseEvent().Dispose();

            if (controlsModel.val_status.InvokeRequired)
            {
                controlsModel.val_status.Invoke(new MethodInvoker(() =>
                {
                    controlsModel.val_status.Text = "Download Completed";
                }));
            }
            else
            {
                controlsModel.val_status.Text = "Download Completed";
            }
        }
    }
}
