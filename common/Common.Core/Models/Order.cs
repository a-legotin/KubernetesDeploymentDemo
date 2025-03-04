using System;
using System.Text.Json.Serialization;

namespace Common.Core.Models;

public class Order
{
    [JsonPropertyName("id")] public long Id { get; set; }

    [JsonPropertyName("guid")] public Guid Guid { get; set; }

    [JsonPropertyName("customer")] public Customer Customer { get; set; }

    [JsonPropertyName("items")] public CatalogItem[] Items { get; set; }
}