using System;
using Newtonsoft.Json;

namespace Posts.Reddit.RedditResponse
{
    public  class Oembed
    {
        [JsonProperty("provider_url")]
        public Uri ProviderUrl { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("thumbnail_width")]
        public long ThumbnailWidth { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("author_name")]
        public string AuthorName { get; set; }

        [JsonProperty("provider_name")]
        public string ProviderName { get; set; }

        [JsonProperty("thumbnail_url")]
        public Uri ThumbnailUrl { get; set; }

        [JsonProperty("thumbnail_height")]
        public long ThumbnailHeight { get; set; }

        [JsonProperty("author_url")]
        public Uri AuthorUrl { get; set; }
    }
}