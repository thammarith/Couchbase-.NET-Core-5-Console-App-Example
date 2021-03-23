using System.Threading.Tasks;
using Couchbase.Extensions.DependencyInjection;

namespace CouchbaseExample.Services
{
    public interface IExampleService
    {
        public Task Run();
    }

    public class ExampleService : IExampleService
    {
        private readonly INamedBucketProvider _provider;

        public ExampleService(INamedBucketProvider provider)
        {
            _provider = provider;
        }

        public async Task Run()
        {
            var bucket = await _provider.GetBucketAsync();
            // Add your code here
        }
    }
}
