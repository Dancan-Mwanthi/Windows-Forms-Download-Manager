using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_DownloadManager.Models
{
    internal class ControlsModel
    {
        public Label? val_downloadLabel { get; set; }
        public Label? lbl_status { get; set; }
        public Label? val_status { get; set; }
        public Label? val_percentageProgress { get; set; }
        public ProgressBar? val_progressBar { get; set; }
        public Button? btn_togglePause { get; set; }
    }
}
