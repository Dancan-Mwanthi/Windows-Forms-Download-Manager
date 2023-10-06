using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_DownloadManager.UpdateUi
{
    internal class UpdateProgressBar
    {
        public void BeginupdateProgressBar(ProgressBar progressBar, long receivedBytes, long totalBytes)
        {
            xx_updateProgressBar(progressBar, receivedBytes, totalBytes);
        }

        private void xx_updateProgressBar(ProgressBar progressBar, long receivedBytes, long totalBytes)
        {
            int totalMB = (int)(totalBytes / 1024d / 1024d);
            int receivedMB = (int)(receivedBytes / 1024d / 1024d);

            if (totalMB > 0)
            {
                int progressPercentage = receivedMB * 100 / totalMB;

                if (progressPercentage < 1)
                {
                    progressPercentage = 1;
                }

                progressBar.Value = progressPercentage;
            }
        }
    }
}
