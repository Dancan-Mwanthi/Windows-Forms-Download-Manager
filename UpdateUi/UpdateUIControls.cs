using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace wf_DownloadManager.UpdateUi
{
    internal class UpdateUIControls
    {
        public void UpdateUIControl(Control control, string text)
        {
            xx_updateUIControl(control, text);
        }
        private void xx_updateUIControl(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodInvoker(() =>
                {
                    control.Text = text;
                }));
            }
            else
            {
                control.Text = text;
            }
        }
    }
}
