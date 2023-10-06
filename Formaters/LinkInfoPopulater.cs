using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;
using wf_DownloadManager.Models;

namespace wf_DownloadManager.Formaters
{
    internal class LinkInfoPopulater : LinkInfo
    {
        public LinkInfo PopulateLinkInfo(string url)
        {
            string fileExtension = Path.GetExtension(url);

            if(string.IsNullOrEmpty(fileExtension))
                DownloadYoutubeVideo(url);
            else
                DownloadFile(url);

            this.downloadFolderWithFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", this.linkLabel);

            return this;
        }

        private void DownloadYoutubeVideo(string url)
        {
            //using (var client = new VideoClient())
            //{
            //    client.HeadAsync(url).Wait();
            //} ;


            ////https://fmoviesz.to/tv/gen-v-4wrjk/1-1

            //var vi = Video;

            //Video video1 = YouTube.Default;
            ////video1.

            var youTube = YouTube.Default; // Starting point for YouTube actions
            YouTubeVideo video = youTube.GetVideo(url); // Gets a Video object with info about the video
            this.uri = new Uri(video.Uri);
            this.linkLabel = video.FullName;
        }

        private void DownloadFile(string url)
        {
            this.uri = new Uri(url);
            this.linkLabel = Path.GetFileName(url);
        }
    }
}
