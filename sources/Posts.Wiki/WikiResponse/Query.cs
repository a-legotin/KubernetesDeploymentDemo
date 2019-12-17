using Newtonsoft.Json;

namespace Posts.Wiki.WikiResponse
{
    public  class Query
    {
        [JsonProperty("random")]
        public Random[] Random { get; set; }
    }
}