using AltoHttp;
using VideoLibrary;
using System;
using System.IO;
using System.Windows.Forms;
using System.Net;
using Microsoft.VisualBasic.Devices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using wf_DownloadManager.Dump;
using System.Threading;
using System.ComponentModel;
using wf_DownloadManager.Formaters;
using wf_DownloadManager.ThreadHandlers;
using wf_DownloadManager.Downloader;
using wf_DownloadManager.Models;

namespace wf_DownloadManager
{
    public partial class Form1 : Form
    {
        //public delegate void DownloadCompletedDelegate(string filePath);
        //public event DownloadCompletedDelegate OnDownloadCompleted;

        //private static object xlock = new object();
        ////public static object _lock = new object();
        //public static object _lock => xlock;

        private bool xIsPaused = false;
        //private ManualResetEventSlim _pauseEvent = new ManualResetEventSlim(false);

        private static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(); // Create a token source.
        public static CancellationTokenSource _cancellationTokenSource => cancellationTokenSource;
        public static CancellationToken _cancellationToken => cancellationTokenSource.Token;

        //private List<Thread> _downloadThreads;
        private LinkInfoPopulater popLinkInfo;
        private FileDownloader _fileDownloader;

        public Form1()
        {
            InitializeComponent();
            //_downloadThreads = new List<Thread>();
            popLinkInfo = new LinkInfoPopulater();
            _fileDownloader = new FileDownloader(this);

        }

        private async void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                //LinkInfo _linkInfo = youtubeFileNameFormater.GetYoutubeDownloadFolderFromLink(txt_Url.Text);
                LinkInfo _linkInfo = popLinkInfo.PopulateLinkInfo(txt_Url.Text);

                await _fileDownloader.BeginDownload(_linkInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Pause_Click(object sender, EventArgs e)
        {
            xIsPaused = TogglePauseThread.TogglePause();
            if (xIsPaused)
            {
                btn_Pause.Text = "Resume";
            }
            else
            {
                btn_Pause.Text = "Pause";
            }
        }
    }


}
