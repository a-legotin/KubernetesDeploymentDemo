using System;
using Newtonsoft.Json;

namespace Posts.Reddit.RedditResponse
{
    public  class RedditVideo
    {
        [JsonProperty("fallback_url")]
        public Uri FallbackUrl { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("scrubber_media_url")]
        public Uri ScrubberMediaUrl { get; set; }

        [JsonProperty("dash_url")]
        public Uri DashUrl { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("hls_url")]
        public Uri HlsUrl { get; set; }

        [JsonProperty("is_gif")]
        public bool IsGif { get; set; }

        [JsonProperty("transcoding_status")]
        public string TranscodingStatus { get; set; }
    }
}