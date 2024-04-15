using Scorpio.DependencyInjection;

namespace Scorpio.EntityFrameworkCore
{
    internal class StringValueProvider : IStringValueProvider, ISingletonDependency
    {
        public string Value { get; set; } = "Row0";
    }
}