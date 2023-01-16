using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Sender
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {

	                    x.UsingAzureServiceBus((context, cfg) =>
						{

							cfg.Host("Endpoint=sb://platform-dinil-uks.servicebus.windows.net/;SharedAccessKeyName=Sender-Consumer;SharedAccessKey=mVxcwnYTjBJmaKZmkgkMYq+O82q/hpG2/8XgGDZ/HuQ=");
							
						});
                    });

                    services.AddHostedService<Worker>();
                });
    }
}
