
using Microsoft.Extensions.DependencyInjection;

using Scorpio.TestBase;

using Shouldly;

using Xunit;

namespace Scorpio.Domain
{
    public class ModuleTests : IntegratedTest<TestModule>
    {
        protected override void SetBootstrapperCreationOptions(BootstrapperCreationOptions options) => options.UseAspectCore();
        [Fact]
        public void GetAppService() => ServiceProvider.GetRequiredService<ITestAppService>().ShouldBeOfType<TestAppService>();
    }
}
