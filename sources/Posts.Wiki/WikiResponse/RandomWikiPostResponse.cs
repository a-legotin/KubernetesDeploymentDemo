using Newtonsoft.Json;

namespace Posts.Wiki.WikiResponse
{
    public class RandomWikiPostResponse
    {
        [JsonProperty("batchcomplete")]
        public string Batchcomplete { get; set; }

        [JsonProperty("continue")]
        public Continue Continue { get; set; }

        [JsonProperty("query")]
        public Query Query { get; set; }

        public static RandomWikiPostResponse FromJson(string json) =>
            JsonConvert.DeserializeObject<RandomWikiPostResponse>(json, Converter.Settings);
    }
}