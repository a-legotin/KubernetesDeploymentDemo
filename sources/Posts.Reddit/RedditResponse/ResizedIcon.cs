using System;
using Newtonsoft.Json;

namespace Posts.Reddit.RedditResponse
{
    public  class ResizedIcon
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }
}