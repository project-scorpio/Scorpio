using System;
using System.Collections.Generic;

namespace Scorpio.DependencyInjection.Conventional
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRegisterAssemblyServiceSelector
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="componentType"></param>
        /// <returns></returns>
        IEnumerable<Type> Select(Type componentType);
    }
}
