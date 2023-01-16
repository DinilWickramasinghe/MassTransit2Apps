namespace Sender.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Sender.Contracts;

    public class SenderConsumer :
        IConsumer<Consumer>
    {
	    readonly ILogger<SenderConsumer> _logger;

	    public SenderConsumer(ILogger<SenderConsumer> logger)
	    {
		    _logger = logger;
	    }
		public Task Consume(ConsumeContext<Consumer> context)
        {

	        _logger.LogInformation("Received Text: {Text}", context.Message.Value);
	        return Task.CompletedTask;
		}
    }
}