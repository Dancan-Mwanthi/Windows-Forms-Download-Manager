using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using VideoLibrary;

namespace FileDownloader
{
    class FileDownload_02
    {
        // Completion download event
        public delegate void DownloadCompletedDelegate(string filePath);
        public event DownloadCompletedDelegate OnDownloadCompleted;

        private object _lock = new object();
        private bool _bPause = false;
        private string _downloadFolder; // Specify the download folder path here

        // Constructor to specify the download folder
        public FileDownload_02(string downloadFolder)
        {
            _downloadFolder = downloadFolder;
        }

        //// Pause download
        //public void Pause()
        //{
        //    lock (_lock)
        //    {
        //        _bPause = true;
        //    }
        //}

        //// Resume download
        //public void Resume()
        //{
        //    lock (_lock)
        //    {
        //        _bPause = false;
        //    }
        //}

        //// Begin download with URI
        //public async Task BeginDownload(Uri uri)
        //{
        //    // Create Background thread
        //    Thread downloadThread = new Thread(async () =>
        //    {
        //        WebRequest webRequest = WebRequest.Create(uri);
        //        WebResponse webResponse = webRequest.GetResponse();

        //        string filePath = Path.Combine(_downloadFolder);

        //        //using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        //        using (WebClient client = new WebClient())
        //        using (Stream webStream = webResponse.GetResponseStream())
        //        {
        //            byte[] buffer = new byte[256];
        //            int readCount = 1;

        //            //client.DownloadProgressChanged += HttpDownloader_ProgressChanged;

        //            while (readCount > 0)
        //            {
        //                // Read download stream
        //                readCount = webStream.Read(buffer, 0, buffer.Length);

        //                if (readCount > 0)
        //                {
        //                    // Write to file
        //                    //fileStream.WriteAsync(buffer, 0, readCount);
        //                    await client.DownloadFileTaskAsync(uri, _downloadFolder);

        //                    // Waiting 100msec while _bPause is true
        //                    while (true)
        //                    {
        //                        lock (_lock)
        //                        {
        //                            if (_bPause)
        //                            {
        //                                Thread.Sleep(100);
        //                            }
        //                            else
        //                            {
        //                                break;
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        // Fire Completion event with the downloaded file path
        //        OnDownloadCompleted?.Invoke(filePath);
        //    });

        //    // Start background thread job
        //    downloadThread.Start();
        //}
    }
}
