using System;
using Newtonsoft.Json;

namespace Posts.Reddit.RedditResponse
{
    public  class AllAwarding
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("is_enabled")]
        public bool IsEnabled { get; set; }

        [JsonProperty("subreddit_id")]
        public object SubredditId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("end_date")]
        public object EndDate { get; set; }

        [JsonProperty("award_sub_type")]
        public string AwardSubType { get; set; }

        [JsonProperty("coin_reward")]
        public long CoinReward { get; set; }

        [JsonProperty("icon_url")]
        public Uri IconUrl { get; set; }

        [JsonProperty("days_of_premium")]
        public long DaysOfPremium { get; set; }

        [JsonProperty("is_new")]
        public bool IsNew { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("icon_height")]
        public long IconHeight { get; set; }

        [JsonProperty("resized_icons")]
        public ResizedIcon[] ResizedIcons { get; set; }

        [JsonProperty("days_of_drip_extension")]
        public long DaysOfDripExtension { get; set; }

        [JsonProperty("award_type")]
        public string AwardType { get; set; }

        [JsonProperty("start_date")]
        public object StartDate { get; set; }

        [JsonProperty("coin_price")]
        public long CoinPrice { get; set; }

        [JsonProperty("icon_width")]
        public long IconWidth { get; set; }

        [JsonProperty("subreddit_coin_reward")]
        public long SubredditCoinReward { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}