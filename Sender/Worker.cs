namespace Sender;

using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Contracts;

public class Worker : BackgroundService
{
	readonly IBus _bus;

	public Worker(IBus bus)
	{
		_bus = bus;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		while (!stoppingToken.IsCancellationRequested)
		{
			await _bus.Publish(new Consumer { Value = $"The time is {DateTimeOffset.Now}" }, stoppingToken);
			Console.WriteLine("Published" + DateTimeOffset.Now);
			await Task.Delay(1000, stoppingToken);
		}
	}
}
