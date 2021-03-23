using System;
using Couchbase.Extensions.DependencyInjection;
using CouchbaseExample.Options;
using CouchbaseExample.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CouchbaseExample
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            #region Settings
            serviceCollection.AddSingleton<AppSettings>(_ =>
            {
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", false, true);
                return configuration.Build().Get<AppSettings>();
            });
            #endregion

            #region Libraries
            serviceCollection.AddCouchbase(options =>
            {
                Console.WriteLine(Configuration.GetSection("CouchbaseOptions").Get<CouchbaseOptions>());
                Configuration.GetSection("CouchbaseOptions").Bind(options);
            });
            serviceCollection.AddCouchbaseBucket<INamedBucketProvider>("bucket-name");
            #endregion

            #region Services
            serviceCollection.AddSingleton<IExampleService, ExampleService>();
            #endregion
        }
    }
}
