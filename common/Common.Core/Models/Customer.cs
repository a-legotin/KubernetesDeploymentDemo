using System;
using System.Text.Json.Serialization;

namespace Common.Core.Models;

public class Customer
{
    [JsonPropertyName("id")] public long Id { get; set; }

    [JsonPropertyName("guid")] public Guid Guid { get; set; }

    [JsonPropertyName("first_name")] public string FirstName { get; set; }

    [JsonPropertyName("last_name")] public string LastName { get; set; }

    [JsonPropertyName("email")] public string Email { get; set; }

    [JsonPropertyName("gender")] public string Gender { get; set; }

    [JsonPropertyName("updatedAt")] public DateTime UpdatedAt { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}