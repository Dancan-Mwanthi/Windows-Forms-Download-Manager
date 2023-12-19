using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wf_DownloadManager.UpdateUi;
using wf_DownloadManager.Utilities;

namespace wf_DownloadManager.Models
{
    internal class ControlPanel : ControlsModel
    {
        public CancellationTokenSource cancellationToken { get; set; } = new();
    }
}
