using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace wf_DownloadManager.Downloader
{
    internal class Internet_Configuration_Request
    {
        public HttpWebRequest ConfigureWebRequest(Uri uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            request.AllowAutoRedirect = false;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:12.0) Gecko/20100101 Firefox/12.0";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Headers[HttpRequestHeader.AcceptLanguage] = "ru,en;q=0.8,en-us;q=0.5,uk;q=0.3";
            request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
            request.KeepAlive = true;
            request.Timeout = 20000;
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            return request;
        }
    }
}
