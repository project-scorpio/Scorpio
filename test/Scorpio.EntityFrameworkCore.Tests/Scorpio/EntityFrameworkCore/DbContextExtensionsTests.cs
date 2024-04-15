
using Microsoft.Extensions.DependencyInjection;

using Shouldly;

using Xunit;

namespace Scorpio.EntityFrameworkCore
{
    public class DbContextExtensionsTests : EntityFrameworkCoreTestBase
    {
        [Fact]
        public void HasRelationalTransactionManager()
        {
            using (var context = ServiceProvider.GetService<TestDbContext>())
            {
                context.HasRelationalTransactionManager().ShouldBeFalse();
            }

        }
    }
}
