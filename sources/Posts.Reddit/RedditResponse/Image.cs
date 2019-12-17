using Newtonsoft.Json;

namespace Posts.Reddit.RedditResponse
{
    public  class Image
    {
        [JsonProperty("source")]
        public ResizedIcon Source { get; set; }

        [JsonProperty("resolutions")]
        public ResizedIcon[] Resolutions { get; set; }

        [JsonProperty("variants")]
        public Variants Variants { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}