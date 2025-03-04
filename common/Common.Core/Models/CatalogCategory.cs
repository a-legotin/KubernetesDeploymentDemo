using System;
using System.Text.Json.Serialization;

namespace Common.Core.Models;

public class CatalogCategory
{
    [JsonPropertyName("guid")] public Guid Guid { get; set; }

    [JsonPropertyName("description")] public string Description { get; set; }
}