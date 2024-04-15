using Microsoft.Extensions.DependencyInjection;

using Scorpio.BackgroundWorkers;

using Shouldly;

using Xunit;

namespace Scorpio.BackgroundJobs
{
    public class ModuleTests : BackgroundJobsTestBase
    {
        [Fact]
        public void Start() => 
            ServiceProvider.GetService<IBackgroundWorkerManager>()
                           .ShouldBeOfType<BackgroundWorkerManager>().BackgroundWorkers
                           .ShouldHaveSingleItem()
                           .ShouldBeOfType<BackgroundJobWorker>();
    }
}