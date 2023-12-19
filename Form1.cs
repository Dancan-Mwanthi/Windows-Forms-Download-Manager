using wf_DownloadManager.Formaters;
using wf_DownloadManager.Downloader;
using wf_DownloadManager.Models;
using wf_DownloadManager.Utilities;
using System.Windows.Forms;

namespace wf_DownloadManager
{
    public partial class Form1 : Form
    {
        private CreateControls _createControls;
        private LinkInfoPopulater _popLinkInfo = new();
        private FileDownloader _fileDownloader = new();
        private ControlPanel _controlPanel = new();
        public Form1() 
        { 
            InitializeComponent();
            _createControls = new(this);
        }
        private async void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_Url.Text)) return;

                LinkInfoModel _linkInfo = await _popLinkInfo.PopulateLinkInfo(txt_Url.Text);

                _controlPanel = _createControls.Begin();

                await _fileDownloader.BeginDownload(_linkInfo, _controlPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


}
