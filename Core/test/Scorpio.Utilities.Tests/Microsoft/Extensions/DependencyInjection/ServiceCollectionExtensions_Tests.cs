﻿using System;


using Shouldly;

using Xunit;

namespace Microsoft.Extensions.DependencyInjection
{
    public class ServiceCollectionExtensions_Tests
    {
        [Fact]
        public void GetService()
        {
            var services = new ServiceCollection();
            services.AddScoped<IService1, Service1>();
            var serviceProvider = services.BuildServiceProvider();
            var service1 = new Service1();
            serviceProvider.GetService<IService1>(() => service1).ShouldNotBe(service1);
            var service2 = new Service2();
            serviceProvider.GetService<IService2>(() => service2).ShouldBe(service2);
        }

    }

    public interface IService1
    {

    }
    public interface IService2
    {

    }

   

    class Service1 : IService1
    {

    }

    class Service2 : IService2
    {

    }

   
}