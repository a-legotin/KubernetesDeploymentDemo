using Newtonsoft.Json;

namespace Posts.Reddit.RedditResponse
{
    public  class Preview
    {
        [JsonProperty("images")]
        public Image[] Images { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}