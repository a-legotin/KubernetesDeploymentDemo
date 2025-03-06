using System.ComponentModel.DataAnnotations;

namespace Service.Orders.Settings;

internal class OrderGeneratorSettings
{
    [Range(1, 99999)] public int DelayMinutes { get; set; } = 10;
}