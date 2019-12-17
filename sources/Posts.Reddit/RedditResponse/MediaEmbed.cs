using System;
using Newtonsoft.Json;

namespace Posts.Reddit.RedditResponse
{
    public  class MediaEmbed
    {
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public long? Width { get; set; }

        [JsonProperty("scrolling", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Scrolling { get; set; }

        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public long? Height { get; set; }

        [JsonProperty("media_domain_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri MediaDomainUrl { get; set; }
    }
}