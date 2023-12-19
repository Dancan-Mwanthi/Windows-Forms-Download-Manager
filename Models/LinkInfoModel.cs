using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_DownloadManager.Models
{
    internal class LinkInfoModel
    {
        public Uri uri { get; set; }
        public string downloadFolderWithFileName { get; set; } = "";
        public string linkLabel { get; set; } = "";
    }
}
