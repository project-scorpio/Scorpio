
using Microsoft.Extensions.DependencyInjection;

using Scorpio.TestBase;

using Shouldly;

using Xunit;

namespace Scorpio.EntityFrameworkCore
{
    public class DefaultDbContextProviderTests : IntegratedTest<EntityFrameworkCoreTestModule>
    {
        [Fact]
        public void GetDbContext()
        {
            var provider = ServiceProvider.GetService<IDbContextProvider<TestDbContext>>();
            provider.GetDbContext().ShouldNotBeNull();
        }
    }
}
