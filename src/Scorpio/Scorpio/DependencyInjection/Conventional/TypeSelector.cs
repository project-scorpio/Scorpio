using System;
using System.Collections.Generic;

namespace Scorpio.DependencyInjection.Conventional
{
    internal class TypeSelector<T> : IRegisterAssemblyServiceSelector
    {
        public IEnumerable<Type> Select(Type componentType) => new Type[] { typeof(T) };
    }
}