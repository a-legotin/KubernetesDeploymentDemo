using Newtonsoft.Json;

namespace Posts.Reddit.RedditResponse
{
    public  class Child
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("data")]
        public ChildData Data { get; set; }
    }
}