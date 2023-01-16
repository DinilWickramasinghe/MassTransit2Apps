using System.Reflection;
using MassTransit;
using Sender.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMassTransit(x =>
{
	var entryAssembly = Assembly.GetEntryAssembly();

	x.AddConsumer<SenderConsumer>();

	x.UsingAzureServiceBus((context, cfg) =>
	{
		cfg.Host("Endpoint=sb://platform-dinil-uks.servicebus.windows.net/;SharedAccessKeyName=Sender-Consumer;SharedAccessKey=mVxcwnYTjBJmaKZmkgkMYq+O82q/hpG2/8XgGDZ/HuQ=");


		cfg.ReceiveEndpoint("consumer", e =>
		{

			e.ConfigureConsumer<SenderConsumer>(context);
		});
		cfg.ConfigureEndpoints(context);
	});
});

var app = builder.Build();


app.Run();
