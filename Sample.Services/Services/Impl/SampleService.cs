using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Services.Services
{
    public class SampleService : ISampleService
    {
        private const int _millisecondsDelay = 1_000;
        private readonly List<string> _sampleDataList = new(capacity: 5)
        {
            "Sample data 1",
            "Sample data 2",
            "Sample data 3",
            "Sample data 4",
            "Sample data 5",
        };

        public async Task<IEnumerable<string>> GetSampleDataAsync(CancellationToken cancellationToken = default)
        {
            var sampleDataResult = new List<string>(capacity: 5);

            foreach (var sampleData in _sampleDataList)
            {
                sampleDataResult.Add(sampleData);
                await Task.Delay(_millisecondsDelay, cancellationToken);
            }

            return sampleDataResult;
        }
    }
}
