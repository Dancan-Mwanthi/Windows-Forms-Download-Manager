using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wf_DownloadManager.Models;
using wf_DownloadManager.ThreadHandlers;
using wf_DownloadManager.UpdateUi;

namespace wf_DownloadManager.Downloader
{
    internal class ProgressChanged
    {
        UpdateUIControls updateUI = new UpdateUIControls();
        UpdateProgressBar updateProgressBar = new UpdateProgressBar();
        private long previousBytesReceived = 0;
        private DateTime previousUpdateTime = DateTime.Now;
        Control val_Status;
        Control progressBar;
        Control val_progressPercentage;
        Control val_downloaded;
        Control btn_Start;
        Control val_downloadLabel;

        public ProgressChanged(Form form)
        {
            initUiElements(form);
        }

        public void eProgressChanged(object sender, 
                                    DownloadProgressChangedEventArgs e, 
                                    string linkLabel)
        {
            xx_progressChanged(sender, e, linkLabel);
        }

        private void initUiElements(Form form)
        {
            val_Status = form.Controls.Find("val_Status", true).FirstOrDefault();
            progressBar = form.Controls.Find("progressBar", true).FirstOrDefault();
            val_progressPercentage = form.Controls.Find("val_progressPercentage", true).FirstOrDefault();
            val_downloaded = form.Controls.Find("val_downloaded", true).FirstOrDefault();
            btn_Start = form.Controls.Find("btn_Start", true).FirstOrDefault();
            val_downloadLabel = form.Controls.Find("val_downloadLabel", true).FirstOrDefault();
        }

        private void xx_progressChanged(object sender, DownloadProgressChangedEventArgs e, string linkLabel)
        {
            if (TogglePauseThread.IsPaused())
                TogglePauseThread.GetPauseEvent().Wait();


            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new MethodInvoker(() =>
                {
                    updateProgressBar.BeginupdateProgressBar((ProgressBar)progressBar, e.BytesReceived, e.TotalBytesToReceive);
                }));
            }

            if (btn_Start.InvokeRequired)
            {
                btn_Start.Invoke(new MethodInvoker(() =>
                {
                    btn_Start.Enabled = false;
                }));
            }
            else
            {
                btn_Start.Enabled = false;
            }

            double speed = CalculateDownloadSpeed(e.BytesReceived);

            updateUI.UpdateUIControl(val_downloadLabel, linkLabel);
            updateUI.UpdateUIControl(val_progressPercentage, $"{e.ProgressPercentage} %");
            updateUI.UpdateUIControl(val_downloaded, string.Format("{0} MB/{1} MB - Speed: {2} KB/s",
                                    (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                                    (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"),
                                    speed.ToString("0.00")));
        }

        private double CalculateDownloadSpeed(long currentBytesReceived)
        {
            DateTime now = DateTime.Now;
            TimeSpan timeElapsed = now - previousUpdateTime;

            if (timeElapsed.TotalSeconds > 0)
            {
                long bytesDownloaded = currentBytesReceived - previousBytesReceived;
                double speedKbps = (bytesDownloaded / 1024d) / timeElapsed.TotalSeconds;
                previousBytesReceived = currentBytesReceived;
                previousUpdateTime = now;
                return speedKbps;
            }

            return 0.0; // Return 0 if time elapsed is too short to calculate speed.
        }
    }
}
