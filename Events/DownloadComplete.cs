using System.ComponentModel;
using wf_DownloadManager.Models;
using wf_DownloadManager.UpdateUi;

namespace wf_DownloadManager.Events
{
    class DownloadComplete
    {
        private UpdateControls _updateControls = new();
        public void eDownloadComplete(
            object sender,
            AsyncCompletedEventArgs e,
            ControlPanel controlPanel)
        {
            _downloadCompleted(sender, e, controlPanel);
        }
        private void _downloadCompleted(
            object sender,
            AsyncCompletedEventArgs e,
            ControlPanel controlPanel)
        {
            if (controlPanel.cancellationToken != null &&
                controlPanel.cancellationToken.IsCancellationRequested)
                controlPanel.cancellationToken?.Cancel();

            _updateControls.ChangeText(controlPanel.val_status, "Download Completed");
            _updateControls.ChangeVisibility(false, controlPanel.val_progressBar);
            _updateControls.ChangeVisibility(false, controlPanel.btn_togglePause);
        }
    }
}
