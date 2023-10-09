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

        private static CancellationTokenSource? cancellationTokenSource; // Create a token source.
        //public static CancellationTokenSource _cancellationTokenSource => cancellationTokenSource;

        public static CancellationTokenSource? _cancellationTokenSource
        {
            get { return cancellationTokenSource; }
            set { cancellationTokenSource = value; }
        }
        public static CancellationToken _cancellationToken => cancellationTokenSource.Token;

        //private List<Thread> _downloadThreads;
        private LinkInfoPopulater popLinkInfo;
        private FileDownloader _fileDownloader;
        private ControlsModel controlsModel;

        private int controlCounter = 3;

        public Form1()
        {
            InitializeComponent();

            //_downloadThreads = new List<Thread>();
            popLinkInfo = new LinkInfoPopulater();
            _fileDownloader = new FileDownloader(this);

        }

        private void moveValuesToControlsModel()
        {
            controlsModel = new ControlsModel();

            controlCounter += 3;

            controlsModel.val_downloadLabel = createNewControl(val_downloadLabel) as Label;
            controlsModel.val_status = createNewControl(val_downloaded) as Label;
            controlsModel.lbl_status = createNewControl(lbl_Status) as Label;
            controlsModel.val_percentageProgress = createNewControl(val_progressPercentage) as Label;
            controlsModel.btn_togglePause = createNewControl(btn_Pause) as System.Windows.Forms.Button;
            controlsModel.val_progressBar = createNewControl(progressBar) as System.Windows.Forms.ProgressBar;

            controlsModel.btn_togglePause.Click += btn_Pause_Click;
        }

        private Control createNewControl(Control originalControl)
        {
            Control newControl = new();

            var test = AccessibilityObject;

            switch (originalControl)
            {
                case System.Windows.Forms.Label:
                    newControl = new System.Windows.Forms.Label();
                    break;
                case System.Windows.Forms.Button:
                    newControl = new System.Windows.Forms.Button();
                    break;
                case System.Windows.Forms.ProgressBar:
                    newControl = new System.Windows.Forms.ProgressBar();
                    break;
            }

            newControl.Name = originalControl.Name+controlCounter;
            newControl.Text = originalControl.Text;
            newControl.Width = originalControl.Width;
            newControl.Location = new System.Drawing.Point(originalControl.Location.X, originalControl.Location.Y + (controlCounter - 1) * 25);
            newControl.AutoSize = true;
            newControl.Visible = true;

            this.Controls.Add(newControl);

            return newControl;
        }

        private async void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                //LinkInfo _linkInfo = youtubeFileNameFormater.GetYoutubeDownloadFolderFromLink(txt_Url.Text);
                LinkInfoModel _linkInfo = popLinkInfo.PopulateLinkInfo(txt_Url.Text);

                moveValuesToControlsModel();
                txt_Url.Text = "";

                await _fileDownloader.BeginDownload(_linkInfo, controlsModel);
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
