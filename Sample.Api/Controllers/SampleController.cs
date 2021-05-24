using Microsoft.AspNetCore.Mvc;
using Sample.Services.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private const int _millisecondsTimeout = 3_000;

        public async Task<IActionResult> GetSampleDataAsync(
            [FromServices] ISampleService sampleService,
            CancellationToken cancellationToken)
        {
            var sampleData = await sampleService
                .GetSampleDataAsync(
                    SetupCancellationToken(cancellationToken));

            return Ok(sampleData);
        }

        private static CancellationToken SetupCancellationToken(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (!cancellationToken.IsCancellationRequested)
            {
                var ctSource = CancellationTokenSource
                    .CreateLinkedTokenSource(cancellationToken);
                ctSource.CancelAfter(_millisecondsTimeout);

                return ctSource.Token;
            }

            return default;
        }
    }
}
