using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DotNetWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IHostedService, Worker>((serviceProvider) =>
                    {
                        return new Worker(serviceProvider.GetService<ILogger<Worker>>());
                    });

                    services.AddSingleton<IHostedService, Worker>((serviceProvider) =>
                    {
                        return new Worker(serviceProvider.GetService<ILogger<Worker>>());
                    });
                });
    }
}
