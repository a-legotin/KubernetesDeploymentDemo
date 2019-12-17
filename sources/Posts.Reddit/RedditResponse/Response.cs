using Newtonsoft.Json;

namespace Posts.Reddit.RedditResponse
{
    public  class RedditPostResponse
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("data")]
        public RedditPostResponseData Data { get; set; }

        public static RedditPostResponse FromJson(string json) =>
            JsonConvert.DeserializeObject<RedditPostResponse>(json);
    }
}