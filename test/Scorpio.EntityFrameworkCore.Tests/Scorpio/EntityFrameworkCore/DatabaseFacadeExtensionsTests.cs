
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Shouldly;

using Xunit;

namespace Scorpio.EntityFrameworkCore
{
    public class DatabaseFacadeExtensionsTests : EntityFrameworkCoreTestBase
    {
        [Fact]
        public void IsRelational()
        {
            using (var context = ServiceProvider.GetService<TestDbContext>())
            {
                context.Database.IsRelational().ShouldBeFalse();
            }

        }
    }
}
