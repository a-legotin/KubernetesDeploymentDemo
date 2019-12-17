using Newtonsoft.Json;

namespace Posts.Reddit.RedditResponse
{
    public  class Media
    {
        [JsonProperty("reddit_video", NullValueHandling = NullValueHandling.Ignore)]
        public RedditVideo RedditVideo { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("oembed", NullValueHandling = NullValueHandling.Ignore)]
        public Oembed Oembed { get; set; }
    }
}