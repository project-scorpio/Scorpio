using System;
using System.Collections.Generic;

using Scorpio.Conventional;

namespace Scorpio.DependencyInjection
{
    internal class EmptyConventionalDependencyRegistrar : IConventionalRegistrar
    {
        public bool RegisterAssemblyInvoked { get; set; }

        public IEnumerable<Type> Types { get; set; }

        public void Register(IConventionalRegistrationContext context)
        {
            Types = context.Types;
            RegisterAssemblyInvoked = true;
        }

    }
}