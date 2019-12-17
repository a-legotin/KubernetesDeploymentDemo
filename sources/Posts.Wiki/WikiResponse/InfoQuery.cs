using System.Collections.Generic;
using Newtonsoft.Json;

namespace Posts.Wiki.WikiResponse
{
    public class InfoQuery
    {
        [JsonProperty("pages")]
        public Dictionary<string, WikiPageInfo> Pages { get; set; }
    }
}