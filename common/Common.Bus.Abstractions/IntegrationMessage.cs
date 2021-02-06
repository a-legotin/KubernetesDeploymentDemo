using System;

namespace Common.Bus.Abstractions
{
    public class IntegrationMessage
    {
        public IntegrationMessage()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        public Guid Id { get; }
        public DateTime CreationDate { get; }
    }
}