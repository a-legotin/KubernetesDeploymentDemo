using Newtonsoft.Json;

namespace Posts.Wiki.WikiResponse
{
    public  class Continue
    {
        [JsonProperty("rncontinue")]
        public string Rncontinue { get; set; }

        [JsonProperty("continue")]
        public string ContinueContinue { get; set; }
    }
}