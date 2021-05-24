using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Services.Services
{
    public interface ISampleService
    {
        Task<IEnumerable<string>> GetSampleDataAsync(CancellationToken cancellationToken = default);
    }
}
