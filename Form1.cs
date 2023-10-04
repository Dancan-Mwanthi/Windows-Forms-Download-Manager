using AltoHttp;
using VideoLibrary;
using System;
using System.IO;
using System.Windows.Forms;
using System.Net;
using Microsoft.VisualBasic.Devices;
using FileDownloader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace wf_DownloadManager
{
    public partial class Form1 : Form
    {
        private HttpDownloader httpDownloader;
        FileDownload_01 fileDownload;
        FileDownload_02 fileDownload_02;

        // Completion download event
        public delegate void DownloadCompletedDelegate(string filePath);
        public event DownloadCompletedDelegate OnDownloadCompleted;

        private object _lock = new object();
        private bool _bPause = false;
        private string _downloadFolder; // Specify the download folder path here
        private ManualResetEventSlim _pauseEvent = new ManualResetEventSlim(false);


        public Form1()
        {
            InitializeComponent();
        }

        private async void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                var url = txt_Url.Text;
                var youTube = YouTube.Default; // Starting point for YouTube actions
                YouTubeVideo video = youTube.GetVideo(txt_Url.Text); // Gets a Video object with info about the video
                _downloadFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", video.FullName);

                await BeginDownload(new Uri(video.Uri));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HttpDownloader_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

            if (_bPause)
                _pauseEvent.Wait();
            

            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new MethodInvoker(() =>
                {
                    UpdateProgressBar(progressBar,e.BytesReceived, e.TotalBytesToReceive);
                }));
            }

            UpdateUIControl(val_Status, "Downloading...");
            UpdateUIControl(val_progressPercentage, $"{e.ProgressPercentage} %");
            UpdateUIControl(val_downloaded, string.Format("{0} MB/{1} MB", (e.BytesReceived / 1024d / 1024d).ToString("0.00"), (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00")));
        }
        private void UpdateProgressBar(System.Windows.Forms.ProgressBar progressBar, long receivedBytes, long totalBytes)
        {
            int totalMB = (int)(totalBytes / 1024d / 1024d);
            int receivedMB = (int)(receivedBytes / 1024d / 1024d);

            if (totalMB > 0)
            {
                int progressPercentage = (receivedMB * 100) / totalMB;

                if (progressPercentage < 1)
                {
                    progressPercentage = 1;
                }

                progressBar.Value = progressPercentage;
            }
        }


        private void UpdateUIControl(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodInvoker(() =>
                {
                    control.Text = text;
                }));
            }
            else
            {
                control.Text = text;
            }
        }
        private void HttpDownloader_DownloadCompleted(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                // Fire Completion event with the downloaded file path
                OnDownloadCompleted?.Invoke(_downloadFolder);
                _pauseEvent.Dispose();

                val_Status.Text = "Download Completed";
                val_progressPercentage.Text = "100%";
            });
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            Pause();
        }

        private void btn_Resume_Click(object sender, EventArgs e)
        {
            Resume();
        }

        public void Pause()
        {
            lock (_lock)
            {
                _bPause = true;
            }
            //_pauseEvent.Reset(); // Set the event to a signaled state (paused).
        }

        public void Resume()
        {
            lock (_lock)
            {
                _bPause = false;
            }
            //_pauseEvent.Set(); // Set the event to a non-signaled state (resumed).
        }
        public async Task BeginDownload(Uri uri)
        {
            // Create Background thread
            Thread downloadThread = new Thread(async () =>
            {
                WebRequest webRequest = WebRequest.Create(uri);
                WebResponse webResponse = webRequest.GetResponse();

                string filePath = Path.Combine(_downloadFolder);

                //using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                using (WebClient client = new WebClient())
                using (Stream webStream = webResponse.GetResponseStream())
                {
                    byte[] buffer = new byte[256];
                    int readCount = 1;

                    client.DownloadProgressChanged += HttpDownloader_ProgressChanged;
                    client.DownloadFileCompleted += HttpDownloader_DownloadCompleted;

                    while (readCount > 0)
                    {
                        // Read download stream
                        readCount = webStream.Read(buffer, 0, buffer.Length);

                        if (readCount > 0)
                        {
                            // Write to file
                            //fileStream.WriteAsync(buffer, 0, readCount);
                            await client.DownloadFileTaskAsync(uri, _downloadFolder);

                            // Waiting 100msec while _bPause is true

                            //while (true)
                            //{
                            //    lock (_lock)
                            //    {
                            //        if (_bPause)
                            //        {
                            //            Thread.Sleep(100);
                            //        }
                            //        else
                            //        {
                            //            break;
                            //        }
                            //    }
                            //}
                        }
                    }
                }

                // Fire Completion event with the downloaded file path
                OnDownloadCompleted?.Invoke(filePath);
            });

            // Start background thread job
            downloadThread.Start();
        }
    }

    
}
