using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wf_DownloadManager.Models;
using wf_DownloadManager.ThreadHandlers;

namespace wf_DownloadManager.Downloader
{
    class FileDownloader
    {
        

        private ProgressChanged progressChanged;
        private DownloadComplete downloadComplete;
        private List<Thread> xdownloadThreads = new List<Thread>();

        public FileDownloader(Form form)
        {
            progressChanged = new ProgressChanged(form);
            downloadComplete = new DownloadComplete(form);
            //xdownloadThreads = _downloadThreads;
        }

        public async Task BeginDownload(LinkInfo linkInfo)
        {
            try
            {
                Thread downloadThread = new Thread(async () =>
                {

                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(linkInfo.uri);
                    webRequest.Method = "GET";
                    webRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
                    WebResponse webResponse = webRequest.GetResponse();

                    using (WebClient client = new WebClient())
                    using (Stream webStream = webResponse.GetResponseStream())
                    {
                        byte[] buffer = new byte[256];
                        int readCount = 1;

                        //client.DownloadProgressChanged += progressChanged.eProgressChanged;

                        client.DownloadProgressChanged += (sender, e) =>
                        {
                            progressChanged.eProgressChanged(sender, e, linkInfo.linkLabel);
                        };


                        client.DownloadFileCompleted += downloadComplete.eDownloadComplete;

                        while (readCount > 0)
                        {
                            if (Form1._cancellationToken.IsCancellationRequested)
                            {
                                Form1._cancellationTokenSource.Dispose();
                                return;
                            }

                            if (TogglePauseThread.IsPaused())
                            {
                                TogglePauseThread.GetPauseEvent().Wait(); // Pause the thread.
                            }

                            readCount = webStream.Read(buffer, 0, buffer.Length);

                            if (readCount > 0)
                            {
                                await client.DownloadFileTaskAsync(linkInfo.uri, linkInfo.downloadFolderWithFileName);
                            }
                        }
                    }
                });

                xdownloadThreads.Add(downloadThread);

                downloadThread.Start();
            }
            catch (OperationCanceledException)
            {
                Form1._cancellationTokenSource.Dispose();
            }
        }
    }
}
