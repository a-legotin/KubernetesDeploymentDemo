using System;
using Common.Core.Models;

namespace Common.Bus.Events;

public class OrderPostedEvent : BaseIntegrationMessage
{
    public Order Order { get; set; }
}

public class BaseIntegrationMessage
{
    public BaseIntegrationMessage()
    {
        CorrelationId = Guid.NewGuid();
        CreatedAt = DateTimeOffset.UtcNow;
    }

    public BaseIntegrationMessage(Guid correlationId, DateTime createdAt)
    {
        CorrelationId = correlationId;
        CreatedAt = createdAt;
    }

    public Guid CorrelationId { get; }
    public DateTimeOffset CreatedAt { get; }
}