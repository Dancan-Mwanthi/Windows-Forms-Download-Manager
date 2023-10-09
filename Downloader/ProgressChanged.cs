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
        Dictionary<string, string> controlsLabel = new Dictionary<string, string>();
        Dictionary<string, long> controlsInternetSpeed = new Dictionary<string, long>();
        UpdateProgressBar updateProgressBar = new UpdateProgressBar();
        private long previousBytesReceived = 0;
        private DateTime previousUpdateTime = DateTime.Now;
        Control val_Status;
        Control progressBar;
        Control val_progressPercentage;
        Control val_downloaded;
        Control btn_Start;
        Control txt_Url;
        Control val_downloadLabel;

        public ProgressChanged(Form form)
        {
            initUiElements(form);
        }

        public void eProgressChanged(object sender, 
                                    DownloadProgressChangedEventArgs e, 
                                    string linkLabel,
                                    ControlsModel controlsModel)
        {
            xx_progressChanged(sender, e, linkLabel, controlsModel);
        }

        private void initUiElements(Form form)
        {
            val_Status = form.Controls.Find("val_Status", true)?.FirstOrDefault();
            progressBar = form.Controls.Find("progressBar", true)?.FirstOrDefault();
            val_progressPercentage = form.Controls.Find("val_progressPercentage", true)?.FirstOrDefault();
            val_downloaded = form.Controls.Find("val_downloaded", true)?.FirstOrDefault();
            btn_Start = form.Controls.Find("btn_Start", true)?.FirstOrDefault();
            val_downloadLabel = form.Controls.Find("val_downloadLabel", true)?.FirstOrDefault();
            txt_Url = form.Controls.Find("txt_Url", true)?.FirstOrDefault();
        }

        private void xx_progressChanged(object sender, DownloadProgressChangedEventArgs e, string linkLabel, ControlsModel controlsModel)
        {
            if (TogglePauseThread.IsPaused())
                TogglePauseThread.GetPauseEvent().Wait();


            if (controlsModel.val_progressBar.InvokeRequired)
            {
                controlsModel.val_progressBar.Invoke(new MethodInvoker(() =>
                {
                    updateProgressBar.BeginupdateProgressBar((ProgressBar)controlsModel.val_progressBar, e.BytesReceived, e.TotalBytesToReceive);
                }));
            }

            //Dictionary<string, string> controlsLabel = new Dictionary<string, string>();

            if (controlsLabel.ContainsKey(controlsModel.val_downloadLabel.Name) == false)
            {
                controlsLabel.Add(controlsModel.val_downloadLabel.Name, linkLabel);
            }
            if (controlsInternetSpeed.ContainsKey(controlsModel.val_status.Name) == false)
            {
                controlsInternetSpeed.Add(controlsModel.val_status.Name, previousBytesReceived);
            }

            previousBytesReceived = controlsInternetSpeed[controlsModel.val_status.Name];

            updateUI.UpdateUIControl(controlsModel.val_downloadLabel, controlsLabel[controlsModel.val_downloadLabel.Name]);
            //updateUI.UpdateUIControl(controlsModel.val_downloadLabel, linkLabel);
            updateUI.UpdateUIControl(controlsModel.val_percentageProgress, $"{e.ProgressPercentage} %");
            updateUI.UpdateUIControl(controlsModel.val_status, internetSpeed(e));
        }

        //private string internetSpeed(DownloadProgressChangedEventArgs e)
        //{
        //    return string.Format("{0} MB/{1} MB - Speed: {2} KB/s",
        //                            (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
        //                            (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"),
        //                            CalculateDownloadSpeed(e.BytesReceived).ToString("0.00"));
        //}

        private string internetSpeed(DownloadProgressChangedEventArgs e)
        {
            double speed = CalculateDownloadSpeed(e.BytesReceived);
            string speedString;

            if (speed >= 1024d)
            {
                speedString = (speed / 1024d).ToString("0.00") + " MB/s";
            }
            else
            {
                speedString = speed.ToString("0.00") + " KB/s";
            }

            return string.Format("{0} MB/{1} MB - Speed: {2}",
                                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"),
                                speedString);
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

            return 0.0;
        }
    }
}
