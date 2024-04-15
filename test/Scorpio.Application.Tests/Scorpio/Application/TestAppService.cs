using Scorpio.Application.Services;
using Scorpio.DependencyInjection;

namespace Scorpio.Application
{
    internal class TestAppService : ApplicationService, ITestAppService, ITransientDependency
    {

    }
}