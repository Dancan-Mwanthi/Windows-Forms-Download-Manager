using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace wf_DownloadManager.UpdateUi
{
    internal class UpdateUIText
    {
        public void Begin(Control control, string text)
        {
            _updateUIText(control, text);
        }
        private void _updateUIText(Control control, string text)
        {
            if (control.InvokeRequired)
                control.Invoke(new MethodInvoker(() =>
                {
                    control.Text = text;
                }));
            else 
                control.Text = text;
        }
    }
}
