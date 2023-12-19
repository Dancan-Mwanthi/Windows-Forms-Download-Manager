using System.Net;
using wf_DownloadManager.Models;
using wf_DownloadManager.ThreadHandlers;
using wf_DownloadManager.UpdateUi;
using wf_DownloadManager.Utilities;

namespace wf_DownloadManager.Events
{
    internal class ProgressChanged
    {
        private UpdateControls _updateControls = new();
        IInternet_Speed _internet_Speed = new Internet_Speed();
        public void eProgressChanged(
            object sender,
            DownloadProgressChangedEventArgs e,
            ControlPanel controlPanel) =>  _progressChanged(sender, e, controlPanel);

        private void _progressChanged(
            object sender,
            DownloadProgressChangedEventArgs e,
            ControlPanel controlPanel)
        {
            if (TogglePauseThread.IsPaused())
                TogglePauseThread.GetPauseEvent().Wait();

             long previousBytesReceived = controlPanel.controlsInternetSpeed[controlPanel.val_status.Name];

            _updateControls.updateProgressBar(controlPanel.val_progressBar, e);
            _updateControls.updateUiText(controlPanel.val_downloadLabel, controlPanel.controlsLabel[controlPanel.val_downloadLabel.Name]);
            _updateControls.updateUiText(controlPanel.val_percentageProgress, $"{e.ProgressPercentage} %");
            _updateControls.updateUiText(controlPanel.val_status, _internet_Speed.Bandwidth(e, ref previousBytesReceived));

            controlPanel.previousBytesReceived = previousBytesReceived;
        }
    }
}
