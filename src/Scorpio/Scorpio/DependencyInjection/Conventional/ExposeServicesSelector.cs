using System;
using System.Collections.Generic;
using System.Reflection;

namespace Scorpio.DependencyInjection.Conventional
{
    internal class ExposeServicesSelector : IRegisterAssemblyServiceSelector
    {
        public static ExposeServicesSelector Instance { get; } = new ExposeServicesSelector();
        public IEnumerable<Type> Select(Type componentType)
        {
            var attr = componentType.GetAttribute<ExposeServicesAttribute>(inherit:true);
            return attr.GetExposedServiceTypes(componentType);
        }
    }
}