using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using wf_DownloadManager.Models;

namespace wf_DownloadManager.Formaters
{
    internal class LinkInfoPopulater : LinkInfoModel
    {
        public async Task<LinkInfoModel> PopulateLinkInfo(string url)
        {
            bool IsNullOrEmpty = string.IsNullOrEmpty(Path.GetExtension(url));

            string youtubeDefaultUrl = YouTube.YoutubeUrl.Replace("https://", "");

            if (url.Contains(youtubeDefaultUrl))
                 await _youtubeExploder(url);
            else if (IsNullOrEmpty)
                DownloadOtherVideos(url);
            else
                _downloadFile(url);
            
            downloadFolderWithFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", linkLabel);

            return this;
        }

        private void DownloadOtherVideos(string url)
        {
            ////https://fmoviesz.to/tv/gen-v-4wrjk/1-1

            //this.uri = new Uri(url);
            //this.linkLabel = Path.GetFileName(url);
        }

        private async Task _youtubeExploder(string url)
        {
            var streamManifest = await new YoutubeClient().Videos.Streams.GetManifestAsync(url);

            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

            YouTubeVideo video = await YouTube.Default.GetVideoAsync(url); // Gets a Video object with info about the video

            uri = new Uri(streamInfo.Url);
            linkLabel = video.FullName;
        }
        private void _downloadFile(string url)
        {
            uri = new Uri(url);
            linkLabel = Path.GetFileName(url);
        }
    }
}
