using System.Net;
using wf_DownloadManager.Events;
using wf_DownloadManager.Models;

namespace wf_DownloadManager.Downloader
{
    class FileDownloader
    {
        private readonly Internet_Configuration_Request _internet_Config = new();
        private readonly ProgressChanged _progressChanged = new ();
        private readonly DownloadComplete _downloadComplete = new();
        private readonly Execute_Download _executeDownload = new();
        public async Task BeginDownload(
            LinkInfoModel linkInfo, 
            ControlPanel controlPanel)
        {
            await Task.Run(async () =>
            {
                try
                {
                    HttpWebRequest request = _internet_Config.ConfigureWebRequest(linkInfo.uri);

                    using (var client = new WebClient())
                    using (var webResponse = await request.GetResponseAsync().ConfigureAwait(false))
                    using (var webStream = webResponse.GetResponseStream())
                    {
                        client.DownloadProgressChanged += async (sender, e) =>
                        {
                            controlPanel.linkLabel = linkInfo.linkLabel;
                            _progressChanged.eProgressChanged(sender, e, controlPanel);
                            await Task.Delay(10000);
                        };

                        client.DownloadFileCompleted += (sender, e) =>
                        {
                            _downloadComplete.eDownloadComplete(sender, e, controlPanel);
                        };

                        await _executeDownload.Begin(client, webStream, linkInfo, controlPanel);
                    }
                }
                catch (WebException ex)
                {
                    MessageBox.Show($"Error: {ex.Message} FileName: {controlPanel.val_downloadLabel}");
                }
            });
        }
    }
}
