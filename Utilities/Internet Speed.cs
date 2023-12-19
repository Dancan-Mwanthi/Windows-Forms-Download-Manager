using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace wf_DownloadManager.Utilities
{
    internal class Internet_Speed : IInternet_Speed
    {
        private DateTime _previousUpdateTime = DateTime.Now;
        private const double BytesInKB = 1024d;
        private const double BytesInMB = BytesInKB * 1024d;
        private const double BytesInGB = BytesInMB * 1024d;
        public string Bandwidth(
            DownloadProgressChangedEventArgs e,
            ref long previousBytesReceived)
        {
            return _internetSpeed(e, ref previousBytesReceived);
        }
        public int Bandwidth(
            DownloadProgressChangedEventArgs e)
        {
            return _internetSpeed(e);
        }
        private int _internetSpeed(
            DownloadProgressChangedEventArgs e)
        {
            int progressPercentage = 0, totalMB, receivedMB;

            totalMB = (int)(e.TotalBytesToReceive / BytesInKB);
            receivedMB = (int)(e.BytesReceived / BytesInKB);

            if (totalMB > 0) 
                progressPercentage = receivedMB * 100 / totalMB;

            if (progressPercentage < 1) 
                progressPercentage = 1;

            return progressPercentage;
        }
        private string _internetSpeed(
            DownloadProgressChangedEventArgs e,
            ref long previousBytesReceived)
        {
            double speed = _calculateDownloadSpeed(e.BytesReceived, ref previousBytesReceived);
            (string unitSpeed, string unit, double byteSize)[] units = 
                { ("B/s", "B", 1d), ("KB/s","KB", BytesInKB), ("MB/s","MB", BytesInMB), ("GB/s","GB", BytesInGB) };
            int speedUnit = units.Length - 1;

            while (speed >= BytesInKB)
            {
                speed /= BytesInKB;
                speedUnit--;
            }

            string FormatBytes(double bytes)
            {
                int index = units.Length - 1;

                while (index >= 0  && bytes !< units[index].byteSize)
                {
                    index--;
                }

                return $"{(bytes / units[index].byteSize):0.00}  {units[index].unit}";
            }

            return $"{FormatBytes(e.BytesReceived)} / {FormatBytes(e.TotalBytesToReceive)} - Speed: {(speed):0.00} {units[speedUnit].unitSpeed}";
        }
        private double _calculateDownloadSpeed(
            long currentBytesReceived,
            ref long previousBytesReceived)
        {
            DateTime now = DateTime.Now;
            TimeSpan timeElapsed = now - _previousUpdateTime;
            double byteRate = 0.0;

            if (timeElapsed.TotalSeconds > 0)
            {
                long bytesDownloaded = currentBytesReceived - previousBytesReceived;
                byteRate = (bytesDownloaded / BytesInKB) / timeElapsed.TotalSeconds;
                previousBytesReceived = currentBytesReceived;
                _previousUpdateTime = now;
            }

            return byteRate;
        }
    }
}
