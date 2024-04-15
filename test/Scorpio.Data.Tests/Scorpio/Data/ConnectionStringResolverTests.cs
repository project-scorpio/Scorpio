using Microsoft.Extensions.DependencyInjection;

using Shouldly;

using Xunit;

namespace Scorpio.Data
{
    public class ConnectionStringResolverTests : TestBase.IntegratedTest<ConnectionStringResolverModule>
    {
        public IConnectionStringResolver Resolver { get; set; }
        public ConnectionStringResolverTests() => Resolver = ServiceProvider.GetRequiredService<IConnectionStringResolver>();

        [Fact]
        public void ResolveDefault() => Resolver.Resolve().ShouldBe("DefaultConnection");

        [Fact]
        public void ResolveName() => Resolver.Resolve("Connection1").ShouldBe("ConnectionString1");
        [Fact]
        public void ResolveDefaultObject() => Resolver.Resolve<DefaultResolveable>().ShouldBe("DefaultConnection");

        [Fact]
        public void ResolveNameObject() => Resolver.Resolve<NamedResolveable>().ShouldBe("ConnectionString1");
    }
}
