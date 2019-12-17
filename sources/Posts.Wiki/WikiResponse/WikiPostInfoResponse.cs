using Newtonsoft.Json;

namespace Posts.Wiki.WikiResponse
{
    public class WikiPostInfoResponse
    {
        [JsonProperty("batchcomplete")]
        public string Batchcomplete { get; set; }

        [JsonProperty("query")]
        public InfoQuery Query { get; set; }

        public static WikiPostInfoResponse FromJson(string json) =>
            JsonConvert.DeserializeObject<WikiPostInfoResponse>(json);
    }
}