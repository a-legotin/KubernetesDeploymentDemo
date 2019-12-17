using Newtonsoft.Json;

namespace Posts.Reddit.RedditResponse
{
    public  class RedditPostResponseData
    {
        [JsonProperty("modhash")]
        public string Modhash { get; set; }

        [JsonProperty("dist")]
        public long Dist { get; set; }

        [JsonProperty("children")]
        public Child[] Children { get; set; }

        [JsonProperty("after")]
        public string After { get; set; }

        [JsonProperty("before")]
        public object Before { get; set; }
    }
}