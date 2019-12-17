using Newtonsoft.Json;

namespace Posts.Reddit.RedditResponse
{
    public  class Gildings
    {
        [JsonProperty("gid_1", NullValueHandling = NullValueHandling.Ignore)]
        public long? Gid1 { get; set; }

        [JsonProperty("gid_3", NullValueHandling = NullValueHandling.Ignore)]
        public long? Gid3 { get; set; }
    }
}