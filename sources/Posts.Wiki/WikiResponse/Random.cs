using Newtonsoft.Json;

namespace Posts.Wiki.WikiResponse
{
    public  class Random
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("ns")]
        public long Ns { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}