using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wf_DownloadManager.ThreadHandlers;

namespace wf_DownloadManager.Events
{
    internal class Events_Factory
    {
        public void _ePause_Click(object sender, EventArgs e, Button button)
        {
            button.Text = TogglePauseThread.TogglePause() ? "Resume" : "Pause";
        }
    }
}
