using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_DownloadManager.Models
{
    internal class ControlsModel
    {
        private ConcurrentDictionary<string, long>? _controlsInternetSpeed;
        private ConcurrentDictionary<string, string>? _controlsLabel;

        public Label val_downloadLabel { get; set; } = new Label();
        public Label lbl_status { get; set; } = new Label();
        public Label val_status { get; set; } = new Label();
        public Label val_percentageProgress { get; set; } = new Label();
        public ProgressBar val_progressBar { get; set; } = new ProgressBar();
        public Button btn_togglePause { get; set; } = new Button();
        public ConcurrentDictionary<string, long> controlsInternetSpeed
        {
            get
            {
                _controlsInternetSpeed ??= new ConcurrentDictionary<string, long>();

                _controlsInternetSpeed.GetOrAdd(val_status.Name, previousBytesReceived);

                return _controlsInternetSpeed;
            }
        }
        public ConcurrentDictionary<string, string> controlsLabel
        {
            get
            {
                _controlsLabel ??= new ConcurrentDictionary<string, string>();

                _controlsLabel.GetOrAdd(val_downloadLabel.Name, linkLabel);

                return _controlsLabel;
            }
        }
        public string linkLabel { get; set; } = "";
        public long previousBytesReceived { get; set; }
    }
}
