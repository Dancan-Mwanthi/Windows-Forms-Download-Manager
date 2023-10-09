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
        public LinkInfoModel PopulateLinkInfo(string url)
        {
            //string fileExtension = Path.GetExtension(url);

            bool IsNullOrEmpty = string.IsNullOrEmpty(Path.GetExtension(url));

            string youtubeDefaultUrl = YouTube.YoutubeUrl.Replace("https://", "");

            if (url.Contains(youtubeDefaultUrl))
                DownloadYoutubeVideo(url);
            else if (IsNullOrEmpty)
                DownloadOtherVideos(url);
            else
                DownloadFile(url);
            
            this.downloadFolderWithFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", this.linkLabel);

            return this;
        }

        private void DownloadOtherVideos(string url)
        {
            ////https://fmoviesz.to/tv/gen-v-4wrjk/1-1

            //this.uri = new Uri(url);
            //this.linkLabel = Path.GetFileName(url);
        }

        private async void YoutubeExploder(string url)
        {
            var youtube = new YoutubeClient();

            // You can specify either the video URL or its ID
            var videoUrl = url;
            var video = await youtube.Videos.GetAsync(videoUrl);

            var title = video.Title; // "Collections - Blender 2.80 Fundamentals"
            var author = video.Author.ChannelTitle; // "Blender"
            var duration = video.Duration; // 00:07:20

            this.uri = new Uri(video.Url);
            this.linkLabel = video.Title;

            ////var youtube = new YoutubeClient();

            ////var videoUrl = url;
            //var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoUrl);
            //// Get highest quality muxed stream
            //var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
        }

        private async Task DownloadYoutubeVideos(string url)
        {
            var youtube = new YoutubeClient();
            var videoUrl = url;
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoUrl);

            // Get the highest quality video stream (adaptive stream)
            var streamInfo = streamManifest.GetVideoOnlyStreams()
                                            .OrderByDescending(s => s.VideoQuality)
                                            .FirstOrDefault();

            var youTube = YouTube.Default;

            YouTubeVideo video = youTube.GetVideo(url); // Gets a Video object with info about the video

            this.uri = new Uri(streamInfo.Url);
            this.linkLabel = video.FullName;
        }


        private void DownloadYoutubeVideo(string url)
        {
            //await DownloadYoutubeVideos(url);

            var youTube = YouTube.Default;

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
