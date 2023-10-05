//using AltoHttp;
//using VideoLibrary;
//using System;
//using System.IO;
//using System.Windows.Forms;
//using System.Net;
//using Microsoft.VisualBasic.Devices;
//using FileDownloader;

//namespace wf_DownloadManager
//{
//    public partial class Form1 : Form
//    {
//        private HttpDownloader httpDownloader;
//        FileDownload_01 fileDownload;
//        FileDownload_02 fileDownload_02;

//        // Completion download event
//        public delegate void DownloadCompletedDelegate(string filePath);
//        public event DownloadCompletedDelegate OnDownloadCompleted;

//        private object _lock = new object();
//        private bool _bPause = false;
//        private string _downloadFolder; // Specify the download folder path here

//        public Form1()
//        {
//            InitializeComponent();
//        }

//        private async void btn_Start_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                var url = txt_Url.Text;
//                var youTube = YouTube.Default; // Starting point for YouTube actions
//                YouTubeVideo video = youTube.GetVideo(txt_Url.Text); // Gets a Video object with info about the video
//                _downloadFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", video.FullName);

//                //fileDownload = new FileDownload_01(txt_Url.Text, destinationPath);
//                //await fileDownload.Start();

//                //Uri uri = new Uri(url);

//                //fileDownload_02 = new FileDownload_02(destinationPath);
//                await BeginDownload(new Uri(video.Uri));

                

//                //using (WebClient client = new WebClient())
//                //{
//                //    client.DownloadFileCompleted += HttpDownloader_DownloadCompleted;

//                //    client.DownloadProgressChanged += HttpDownloader_ProgressChanged;

//                //    await client.DownloadFileTaskAsync(new Uri(video.Uri), destinationPath);
//                //}

//                ////httpDownloader = new HttpDownloader(txt_Url.Text, destinationPath);
//                ////httpDownloader.DownloadCompleted += HttpDownloader_DownloadCompleted;
//                ////httpDownloader.ProgressChanged += HttpDownloader_ProgressChanged;
//                ////httpDownloader.Start();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void HttpDownloader_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
//        {
//            //progressBar.Value = (int)e.Progress;
//            val_progressPercentage.Text = $"{e.ProgressPercentage.ToString("0.00")} %";
//            //val_speed.Text = string.Format("{0} MB/s", (e.SpeedInBytes / 1024d / 1024d).ToString("0.00"));
//            val_downloaded.Text = string.Format("{0} MB", (e.BytesReceived / 1024d / 1024d).ToString("0.00"));
//            val_Status.Text = "Downloading...";
//        }

//        private void HttpDownloader_DownloadCompleted(object sender, EventArgs e)
//        {
//            this.Invoke((MethodInvoker)delegate
//            {
//                val_Status.Text = "Download Completed";
//                val_progressPercentage.Text = "100%";
//            });
//        }

//        private void btn_Pause_Click(object sender, EventArgs e)
//        {
//            //httpDownloader?.Pause();

//            //fileDownload.Pause();
//            Pause();
//        }

//        private void btn_Resume_Click(object sender, EventArgs e)
//        {
//            //httpDownloader?.Resume();

//            Resume();
//        }

//        // Pause download
//        public void Pause()
//        {
//            lock (_lock)
//            {
//                _bPause = true;
//            }
//        }

//        // Resume download
//        public void Resume()
//        {
//            lock (_lock)
//            {
//                _bPause = false;
//            }
//        }

//        // Begin download with URI
//        public async Task BeginDownload(Uri uri)
//        {
//            // Create Background thread
//            Thread downloadThread = new Thread(async () =>
//            {
//                WebRequest webRequest = WebRequest.Create(uri);
//                WebResponse webResponse = webRequest.GetResponse();

//                string filePath = Path.Combine(_downloadFolder);

//                //using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
//                using (WebClient client = new WebClient())
//                using (Stream webStream = webResponse.GetResponseStream())
//                {
//                    byte[] buffer = new byte[256];
//                    int readCount = 1;

//                    client.DownloadProgressChanged += HttpDownloader_ProgressChanged;
//                    client.DownloadFileCompleted += HttpDownloader_DownloadCompleted;

//                    while (readCount > 0)
//                    {
//                        // Read download stream
//                        readCount = webStream.Read(buffer, 0, buffer.Length);

//                        if (readCount > 0)
//                        {
//                            // Write to file
//                            //fileStream.WriteAsync(buffer, 0, readCount);
//                            await client.DownloadFileTaskAsync(uri, _downloadFolder);

//                            // Waiting 100msec while _bPause is true
//                            while (true)
//                            {
//                                lock (_lock)
//                                {
//                                    if (_bPause)
//                                    {
//                                        Thread.Sleep(100);
//                                    }
//                                    else
//                                    {
//                                        break;
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }

//                // Fire Completion event with the downloaded file path
//                OnDownloadCompleted?.Invoke(filePath);
//            });

//            // Start background thread job
//            downloadThread.Start();
//        }
//    }

    
//}
