using System;
using System.Text.Json.Serialization;

namespace Common.Core.Models;

public class CatalogItem
{
    [JsonPropertyName("guid")] public Guid Guid { get; set; }

    [JsonPropertyName("description")] public string Description { get; set; }

    [JsonPropertyName("cost")] public double Cost { get; set; }

    [JsonPropertyName("category")] public CatalogCategory Category { get; set; }
}