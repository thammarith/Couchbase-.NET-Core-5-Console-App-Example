using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CouchbaseExample.Extensions;
using CouchbaseExample.Services;

namespace CouchbaseExample
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var host = BuildHost(args);
            var service = host.Services.GetService<IExampleService>()
                          ?? throw new NullReferenceException(nameof(IExampleService));
            await service.Run();
        }

        private static IHost BuildHost(string[] args)
        {
            return Host.CreateDefaultBuilder(args).UseStartup<Startup>().Build();
        }
    }
}
