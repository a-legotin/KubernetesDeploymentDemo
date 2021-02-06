using System.Threading.Tasks;

namespace Common.Bus.Abstractions
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
        where TIntegrationEvent : IntegrationMessage
    {
        Task Handle(TIntegrationEvent request);
    }

    public interface IIntegrationEventHandler
    {
    }
}