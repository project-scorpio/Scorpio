using System;
using System.Collections.Generic;

namespace Scorpio.DependencyInjection.Conventional
{
    internal class SelfSelector : IRegisterAssemblyServiceSelector
    {
        public static SelfSelector Instance { get; } = new SelfSelector();
        public IEnumerable<Type> Select(Type componentType) => new Type[] { componentType };
    }
}