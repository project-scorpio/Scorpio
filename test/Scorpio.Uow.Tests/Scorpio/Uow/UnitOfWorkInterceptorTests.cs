using Microsoft.Extensions.DependencyInjection;

using Shouldly;

using Xunit;

namespace Scorpio.Uow
{
    public class UnitOfWorkInterceptorTests : UnitOfWorkTestBase
    {

        [Fact]
        public void Method1()
        {
            var service = ServiceProvider.GetService<IUnitOfWorkTestInterface>();
            Should.NotThrow(() => service.Method1());
        }

        [Fact]
        public void Method1Async()
        {
            var service = ServiceProvider.GetService<IUnitOfWorkTestInterface>();
            Should.NotThrow(() => service.Method1Async());
        }

        [Fact]
        public void DisableMethod()
        {
            var service = ServiceProvider.GetService<IUnitOfWorkTestInterface>();
            Should.NotThrow(() => service.DisableMethod());
        }
    }
}
