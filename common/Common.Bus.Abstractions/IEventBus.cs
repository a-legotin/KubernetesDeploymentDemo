namespace Common.Bus.Abstractions
{
    public interface IEventBus
    {
        void Publish(IntegrationMessage message);

        void Subscribe<T, TH>()
            where T : IntegrationMessage
            where TH : IIntegrationEventHandler<T>;
    }
}