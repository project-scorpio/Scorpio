using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using NSubstitute;

using Shouldly;

using Xunit;

namespace Scorpio.Options
{
    public class OptionsBuilderTests
    {
        public (IServiceCollection, OptionsBuilder<TestExtensibleOptions>) GetServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(Substitute.For<IService1>());
            serviceCollection.AddSingleton(Substitute.For<IService2>());
            serviceCollection.AddSingleton(Substitute.For<IService3>());
            serviceCollection.AddSingleton(Substitute.For<IService4>());
            serviceCollection.AddSingleton(Substitute.For<IService5>());
            serviceCollection.ReplaceOrAdd(ServiceDescriptor.Transient(typeof(IOptionsFactory<>), typeof(OptionsFactory<>)), true);
            var optionsBuilder = serviceCollection.Options<TestExtensibleOptions>();
            return (serviceCollection, optionsBuilder);
        }

        [Fact]
        public void PreConfigure()
        {
            var (services, ob) = GetServices();
            ob.PreConfigure(o => o.SetOption("default", "value"));
            services.ShouldContainSingleton(typeof(IPreConfigureOptions<TestExtensibleOptions>), typeof(PreConfigureOptions<TestExtensibleOptions>))
                .ImplementationInstance.ShouldBeOfType<PreConfigureOptions<TestExtensibleOptions>>().ShouldNotBeNull();
            var servicePorivder = services.BuildServiceProvider();
            var opt = servicePorivder.GetRequiredService<IOptions<TestExtensibleOptions>>();
            opt.Value.ShouldNotBeNull();
            opt.Value.GetOption<string>("default").ShouldBe("value");
        }
        [Fact]
        public void PreConfigureD1()
        {
            var (services, ob) = GetServices();
            ob.PreConfigure<IService1>((o, s) =>
            {
                o.SetOption("default", "value");
                s.As<IService1>().ShouldNotBeNull();
            });
            services.ShouldContainTransient(typeof(IPreConfigureOptions<TestExtensibleOptions>))
                .ImplementationFactory.ShouldBeOfType<Func<IServiceProvider, IPreConfigureOptions<TestExtensibleOptions>>>();
            var servicePorivder = services.BuildServiceProvider();
            var opt = servicePorivder.GetRequiredService<IOptions<TestExtensibleOptions>>();
            opt.Value.ShouldNotBeNull();
        }

        [Fact]
        public void PreConfigureD2()
        {
            var (services, ob) = GetServices();
            ob.PreConfigure<IService1, IService2>((o, s1, s2) =>
            {
                o.SetOption("default", "value");
                s1.As<IService1>().ShouldNotBeNull();
                s2.As<IService2>().ShouldNotBeNull();
            });
            services.ShouldContainTransient(typeof(IPreConfigureOptions<TestExtensibleOptions>))
                .ImplementationFactory.ShouldBeOfType<Func<IServiceProvider, IPreConfigureOptions<TestExtensibleOptions>>>();
            var servicePorivder = services.BuildServiceProvider();
            var opt = servicePorivder.GetRequiredService<IOptions<TestExtensibleOptions>>();
            opt.Value.ShouldNotBeNull();
        }
        [Fact]
        public void PreConfigureD3()
        {
            var (services, ob) = GetServices();

            ob.PreConfigure<IService1, IService2, IService3>((o, s1, s2, s3) =>
            {
                o.SetOption("default", "value");
                s1.As<IService1>().ShouldNotBeNull();
                s2.As<IService2>().ShouldNotBeNull();
                s3.As<IService3>().ShouldNotBeNull();
            });
            services.ShouldContainTransient(typeof(IPreConfigureOptions<TestExtensibleOptions>))
                .ImplementationFactory.ShouldBeOfType<Func<IServiceProvider, IPreConfigureOptions<TestExtensibleOptions>>>();
            var servicePorivder = services.BuildServiceProvider();
            var opt = servicePorivder.GetRequiredService<IOptions<TestExtensibleOptions>>();
            opt.Value.ShouldNotBeNull();
        }
        [Fact]
        public void PreConfigureD4()
        {
            var (services, ob) = GetServices();
            ob.PreConfigure<IService1, IService2, IService3, IService4>((o, s1, s2, s3, s4) =>
            {
                o.SetOption("default", "value");
                s1.As<IService1>().ShouldNotBeNull();
                s2.As<IService2>().ShouldNotBeNull();
                s3.As<IService3>().ShouldNotBeNull();
                s4.As<IService4>().ShouldNotBeNull();
            });
            services.ShouldContainTransient(typeof(IPreConfigureOptions<TestExtensibleOptions>))
                .ImplementationFactory.ShouldBeOfType<Func<IServiceProvider, IPreConfigureOptions<TestExtensibleOptions>>>();
            var servicePorivder = services.BuildServiceProvider();
            var opt = servicePorivder.GetRequiredService<IOptions<TestExtensibleOptions>>();
            opt.Value.ShouldNotBeNull();
        }
        [Fact]
        public void PreConfigureD5()
        {
            var (services, ob) = GetServices();
            ob.PreConfigure<IService1, IService2, IService3, IService4, IService5>((o, s1, s2, s3, s4, s5) =>
            {
                o.SetOption("default", "value");
                s1.As<IService1>().ShouldNotBeNull();
                s2.As<IService2>().ShouldNotBeNull();
                s3.As<IService3>().ShouldNotBeNull();
                s4.As<IService4>().ShouldNotBeNull();
                s5.As<IService5>().ShouldNotBeNull();
            });
            services.ShouldContainTransient(typeof(IPreConfigureOptions<TestExtensibleOptions>))
                .ImplementationFactory.ShouldBeOfType<Func<IServiceProvider, IPreConfigureOptions<TestExtensibleOptions>>>();
            var servicePorivder = services.BuildServiceProvider();
            var opt = servicePorivder.GetRequiredService<IOptions<TestExtensibleOptions>>();
            opt.Value.ShouldNotBeNull();
        }

        public class TestExtensibleOptions : ExtensibleOptions
        {
            public TestExtensibleOptions()
            {

            }
        }

    }
}
