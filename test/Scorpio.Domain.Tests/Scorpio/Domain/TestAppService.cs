using Scorpio.DependencyInjection;
using Scorpio.Domain.Services;

namespace Scorpio.Domain
{
    internal class TestAppService : DomainService, ITestAppService, ITransientDependency
    {

    }
}