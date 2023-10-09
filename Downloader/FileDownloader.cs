using AngleSharp.Text;
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
        private Dictionary<string, string> downloadList = new Dictionary<string, string>();

        public FileDownloader(Form form)
        {
            progressChanged = new ProgressChanged(form);
            downloadComplete = new DownloadComplete(form);
            //xdownloadThreads = _downloadThreads;
        }

        public async Task BeginDownload(LinkInfoModel linkInfo, ControlsModel controlsModel)
        {
            try
            {
                Thread downloadThread = new Thread(async () =>
                {

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(linkInfo.uri);
                    //webRequest.Method = "GET";
                    //webRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";

                    request.AllowAutoRedirect = false;
                    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:12.0) Gecko/20100101 Firefox/12.0";
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    request.Headers[HttpRequestHeader.AcceptLanguage] = "ru,en;q=0.8,en-us;q=0.5,uk;q=0.3";
                    request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
                    request.KeepAlive = true;
                    request.Timeout = 20000;
                    request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                    WebResponse webResponse = request.GetResponse();

                    using (WebClient client = new WebClient())
                    using (Stream webStream = webResponse.GetResponseStream())
                    {
                        byte[] buffer = new byte[256];
                        int readCount = 1;

                        //controlsModel.btn_togglePause.Click += Form1.btn_Pause_Click;
                        //client.DownloadProgressChanged += progressChanged.eProgressChanged;

                        client.DownloadProgressChanged += (sender, e) =>
                        {
                            progressChanged.eProgressChanged(sender, e, linkInfo.linkLabel, controlsModel);
                        };


                        //client.DownloadFileCompleted += downloadComplete.eDownloadComplete;
                        client.DownloadFileCompleted += (sender, e) =>
                        {
                            downloadComplete.eDownloadComplete(sender, e, controlsModel);
                        };


                        while (readCount > 0)
                        {

                            Form1._cancellationTokenSource ??= new CancellationTokenSource(); //null-coalescing assignment operator (??=).

                            if (downloadList.ContainsKey(controlsModel.val_downloadLabel.Name))
                                    Form1._cancellationTokenSource.Cancel();
                            else
                                downloadList.Add(controlsModel.val_downloadLabel.Name, linkInfo.downloadFolderWithFileName);


                            if (Form1._cancellationToken.IsCancellationRequested)
                                return;

                            if (TogglePauseThread.IsPaused())
                                TogglePauseThread.GetPauseEvent().Wait(); // Pause the thread.

                            readCount = webStream.Read(buffer, 0, buffer.Length);

                            if (readCount > 0)
                                await client.DownloadFileTaskAsync(linkInfo.uri, linkInfo.downloadFolderWithFileName);
                            
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
