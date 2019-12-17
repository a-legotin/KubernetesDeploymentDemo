using System;
using Newtonsoft.Json;

namespace Posts.Wiki.WikiResponse
{
    public class WikiPostResponse
    {
        [JsonProperty("parse")]
        public Parse Parse { get; set; }

        public static WikiPostResponse FromJson(string json) => JsonConvert.DeserializeObject<WikiPostResponse>(json);
    }

    public  class Parse
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("pageid")]
        public long Pageid { get; set; }

        [JsonProperty("revid")]
        public long Revid { get; set; }

        [JsonProperty("text")]
        public Text Text { get; set; }

        [JsonProperty("langlinks")]
        public object[] Langlinks { get; set; }

        [JsonProperty("categories")]
        public Category[] Categories { get; set; }

        [JsonProperty("links")]
        public Link[] Links { get; set; }

        [JsonProperty("templates")]
        public Link[] Templates { get; set; }

        [JsonProperty("images")]
        public string[] Images { get; set; }

        [JsonProperty("externallinks")]
        public Uri[] Externallinks { get; set; }

        [JsonProperty("sections")]
        public object[] Sections { get; set; }

        [JsonProperty("parsewarnings")]
        public object[] Parsewarnings { get; set; }

        [JsonProperty("displaytitle")]
        public string Displaytitle { get; set; }

        [JsonProperty("iwlinks")]
        public Iwlink[] Iwlinks { get; set; }

        [JsonProperty("properties")]
        public Property[] Properties { get; set; }
    }

    public  class Category
    {
        [JsonProperty("sortkey")]
        public string Sortkey { get; set; }

        [JsonProperty("hidden", NullValueHandling = NullValueHandling.Ignore)]
        public string Hidden { get; set; }

        [JsonProperty("*")]
        public string Empty { get; set; }
    }

    public  class Iwlink
    {
        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("*")]
        public string Empty { get; set; }
    }

    public  class Link
    {
        [JsonProperty("ns")]
        public long Ns { get; set; }

        [JsonProperty("exists")]
        public string Exists { get; set; }

        [JsonProperty("*")]
        public string Empty { get; set; }
    }

    public  class Property
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("*")]
        public string Empty { get; set; }
    }

    public  class Text
    {
        [JsonProperty("*")]
        public string Content { get; set; }
    }
}