using System;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

namespace Scorpio.DependencyInjection.Conventional
{
    internal class ExposeLifetimeSelector : IRegisterAssemblyLifetimeSelector
    {
        public static ExposeLifetimeSelector Instance { get; } = new ExposeLifetimeSelector();

        public ServiceLifetime Select(Type componentType)
        {
            var attr = componentType.GetAttribute<ExposeServicesAttribute>(true);
            return attr?.ServiceLifetime ?? ServiceLifetime.Transient;
        }
    }
}