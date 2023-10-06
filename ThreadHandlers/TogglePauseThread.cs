using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_DownloadManager.ThreadHandlers
{
    internal static class TogglePauseThread
    {
        private static object lockObject = new ();
        private static bool isPaused;
        private static ManualResetEventSlim pauseEvent = new ManualResetEventSlim(false);

        public static bool TogglePause()
        {
            lock (lockObject)
            {
                isPaused = !isPaused;
                if (!isPaused)
                {
                    pauseEvent.Set(); // Signal to resume if paused.
                }
                else
                {
                    pauseEvent.Reset(); // Reset event to pause.
                }
            }
            return isPaused;
        }

        public static bool IsPaused()
        {
            lock (lockObject)
            {
                return isPaused;
            }
        }

        public static ManualResetEventSlim GetPauseEvent()
        {
            return pauseEvent;
        }
    }

}
