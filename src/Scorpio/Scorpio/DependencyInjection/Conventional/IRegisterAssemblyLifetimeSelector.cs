using System;

using Microsoft.Extensions.DependencyInjection;

namespace Scorpio.DependencyInjection.Conventional
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRegisterAssemblyLifetimeSelector
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="componentType"></param>
        /// <returns></returns>
        ServiceLifetime Select(Type componentType);
    }
}