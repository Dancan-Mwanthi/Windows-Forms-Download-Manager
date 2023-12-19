using System.Net;

namespace wf_DownloadManager.Utilities
{
    internal interface IInternet_Speed
    {
        string Bandwidth(DownloadProgressChangedEventArgs e, ref long previousBytesReceived);
        int Bandwidth(DownloadProgressChangedEventArgs e);
    }
}