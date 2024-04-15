using System;
using System.Collections.Generic;
using System.Linq;

namespace Scorpio.DependencyInjection.Conventional
{
    internal class AllInterfaceSelector : IRegisterAssemblyServiceSelector
    {
        public static AllInterfaceSelector Instance { get; } = new AllInterfaceSelector();
        public AllInterfaceSelector()
        {
        }

        public IEnumerable<Type> Select(Type componentType)
        {
            var services = componentType.GetInterfaces().Where(s => s.IsPublic).ToList();
            services.Add(componentType);
            return services;
        }
    }
}