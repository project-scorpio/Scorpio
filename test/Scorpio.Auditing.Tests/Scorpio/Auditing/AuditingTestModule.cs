using Microsoft.Extensions.DependencyInjection;

using Scorpio.Modularity;
using Scorpio.Security;
using Scorpio.Timing;

namespace Scorpio.Auditing
{
    [DependsOn(typeof(AuditingModule))]
    public class AuditingTestModule : ScorpioModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.ReplaceSingleton<ICurrentPrincipalAccessor, TestPrincipalAccessor>();
            context.Services.ReplaceSingleton<IClock, TestClock>();
            context.Services.Configure<AuditingOptions>(opt =>
            {
                opt.Contributors.Add(new TestContributor());
                opt.IgnoredTypes.Add<AuditingHelperTests.IgnoreClass>();
            });
            context.Services.ReplaceSingleton<IAuditingStore, FackAuditingStore>();
        }

    }
}
