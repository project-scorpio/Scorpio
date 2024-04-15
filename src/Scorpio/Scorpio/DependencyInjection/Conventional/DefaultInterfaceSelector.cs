using System;
using System.Collections.Generic;
using System.Linq;

namespace Scorpio.DependencyInjection.Conventional
{
    internal class DefaultInterfaceSelector : IRegisterAssemblyServiceSelector
    {
        public static DefaultInterfaceSelector Instance { get; } = new DefaultInterfaceSelector();
        public DefaultInterfaceSelector()
        {
        }

        public IEnumerable<Type> Select(Type componentType)
        {
            var services = componentType.GetInterfaces().Where(s => componentType.Name.EndsWith(s.Name.RemovePreFix("I"))).ToList();
            services.Add(componentType);
            return services;
        }
    }
}
