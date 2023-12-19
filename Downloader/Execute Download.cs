using System.Net;
using wf_DownloadManager.Models;
using wf_DownloadManager.ThreadHandlers;

namespace wf_DownloadManager.Downloader
{
    internal class Execute_Download
    {
        private Dictionary<string, string> _downloadList = new();

        public async Task Begin(
            WebClient client,
            Stream webStream,
            LinkInfoModel linkInfo,
            ControlPanel controlPanel) =>  await _DownloadFileAsync(client, webStream, linkInfo, controlPanel);

        private async Task _DownloadFileAsync(
            WebClient client, 
            Stream webStream, 
            LinkInfoModel linkInfo, 
            ControlPanel controlPanel)
        {
            var buffer = new byte[256];
            int readCount = 1;

            while (readCount > 0)
            {
                if (controlPanel.cancellationToken.IsCancellationRequested
                    && _downloadList.ContainsKey(controlPanel.val_downloadLabel.Name))
                    return;

                if (_downloadList.ContainsKey(controlPanel.val_downloadLabel.Name))
                    controlPanel.cancellationToken.Cancel();
                else
                    _downloadList.Add(controlPanel.val_downloadLabel.Name, linkInfo.downloadFolderWithFileName);

                if (TogglePauseThread.IsPaused())
                    TogglePauseThread.GetPauseEvent().Wait(); // Pause the thread.

                readCount = await webStream.ReadAsync(buffer, 0, buffer.Length);

                if (readCount > 0)
                    await client.DownloadFileTaskAsync(linkInfo.uri, linkInfo.downloadFolderWithFileName);
            }
        }
    }
}
