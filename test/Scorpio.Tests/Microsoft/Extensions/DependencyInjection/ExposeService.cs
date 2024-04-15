using Scorpio.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    [ExposeServices(typeof(IExposeService), ServiceLifetime = ServiceLifetime.Singleton)]
    internal class ExposeService : IExposeService
    {

    }
}