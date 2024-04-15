using System;

using Scorpio.DependencyInjection.TestClasses;

using Shouldly;

using Xunit;

namespace Scorpio.DependencyInjection
{
    public class PropertyResolverSelectorTests
    {
        [Fact]
        public void SelectPropertyResolver()
        {
            Should.Throw<ArgumentNullException>(() => PropertyResolverSelector.Default.SelectPropertyResolver(null));
            Should.NotThrow(() =>
                PropertyResolverSelector.Default.SelectPropertyResolver(typeof(PropertyInjectionService))).ShouldHaveSingleItem();
            Should.NotThrow(() =>
                PropertyResolverSelector.Default.SelectPropertyResolver(typeof(ReadOnlyPropertyInjectionService))).ShouldBeEmpty();
            Should.NotThrow(() =>
                PropertyResolverSelector.Default.SelectPropertyResolver(typeof(NonPropertyInjectionService))).ShouldBeEmpty();
        }
    }
}
