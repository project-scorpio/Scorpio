using System;

using Microsoft.Extensions.DependencyInjection;

using Scorpio.Modularity;

namespace Scorpio.TestBase
{
    public abstract class IntegratedTest<TStartupModule> : IntegratedTestBase
        where TStartupModule : IScorpioModule
    {

        protected override IBootstrapper Bootstrapper { get; }

        public override IServiceProvider ServiceProvider => Bootstrapper.ServiceProvider;

        protected IServiceProvider RootServiceProvider { get; }

        protected IServiceScope TestServiceScope { get; }

        protected IntegratedTest()
        {
            var services = new ServiceCollection();
            var bootstrapper = CreateBootstrapper(services);
            Bootstrapper = bootstrapper;
            RootServiceProvider = CreateServiceProvider(bootstrapper);
            TestServiceScope = RootServiceProvider.CreateScope();
            bootstrapper.SetServiceProvider(TestServiceScope.ServiceProvider);
            bootstrapper.Initialize();
        }

        protected virtual Bootstrapper CreateBootstrapper(IServiceCollection services) => new InternalBootstrapper(typeof(TStartupModule), services, null, SetBootstrapperCreationOptions);

        protected virtual IServiceProvider CreateServiceProvider(Bootstrapper bootstrapper)
        {
            var builder = bootstrapper.ServiceFactoryAdapter.CreateBuilder(bootstrapper.Services);
            return bootstrapper.ServiceFactoryAdapter.CreateServiceProvider(builder);
        }
    }
}
