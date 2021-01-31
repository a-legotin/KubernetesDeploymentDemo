using System;
using System.Text.Json.Serialization;

namespace Common.Core.Models
{
    public class Customer
    {
        [JsonPropertyName("guid")]
        public Guid Guid { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }
    }
}