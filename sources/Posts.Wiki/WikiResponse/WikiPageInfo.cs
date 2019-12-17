using System;
using Newtonsoft.Json;

namespace Posts.Wiki.WikiResponse
{
    public  class WikiPageInfo
    {
        [JsonProperty("pageid")]
        public long Pageid { get; set; }

        [JsonProperty("ns")]
        public long Ns { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("contentmodel")]
        public string Contentmodel { get; set; }

        [JsonProperty("pagelanguage")]
        public string Pagelanguage { get; set; }

        [JsonProperty("pagelanguagehtmlcode")]
        public string Pagelanguagehtmlcode { get; set; }

        [JsonProperty("pagelanguagedir")]
        public string Pagelanguagedir { get; set; }

        [JsonProperty("touched")]
        public DateTimeOffset Touched { get; set; }

        [JsonProperty("lastrevid")]
        public long Lastrevid { get; set; }

        [JsonProperty("length")]
        public long Length { get; set; }

        [JsonProperty("fullurl")]
        public Uri Fullurl { get; set; }

        [JsonProperty("editurl")]
        public Uri Editurl { get; set; }

        [JsonProperty("canonicalurl")]
        public Uri Canonicalurl { get; set; }
    }
}