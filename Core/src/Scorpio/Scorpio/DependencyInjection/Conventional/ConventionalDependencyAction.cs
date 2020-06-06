﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Scorpio.Conventional;

namespace Scorpio.DependencyInjection.Conventional
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ConventionalDependencyAction : ConventionalActionBase
    {

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        internal ConventionalDependencyAction(IConventionalConfiguration configuration) 
            : base(configuration)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected override void Action(IConventionalContext context)
        {
            context.Types.ForEach(
                t => context.Get<ICollection<IRegisterAssemblyServiceSelector>>("Service").ForEach(
                    selector => selector.Select(t).ForEach(
                    s => context.Services.ReplaceOrAdd(
                        ServiceDescriptor.Describe(s, t, 
                        context.GetOrAdd<IRegisterAssemblyLifetimeSelector>("Lifetime", 
                        new LifetimeSelector(ServiceLifetime.Transient)).Select(t)),
                        t.GetAttribute<ReplaceServiceAttribute>()?.ReplaceService??false
                        ))));
        }
    }
}
