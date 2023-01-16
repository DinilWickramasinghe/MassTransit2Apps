using MassTransit;

namespace Sender.Consumers
{
	public class SenderConsumerDefinition :
        ConsumerDefinition<SenderConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<SenderConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
        }
    }
}