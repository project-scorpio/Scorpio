using Microsoft.Extensions.DependencyInjection;

using Scorpio.Modularity;

namespace Scorpio.Data
{
    [DependsOn(typeof(DataModule))]
    public class ConnectionStringResolverModule : ScorpioModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.Configure<DbConnectionOptions>(o =>
            {
                o.ConnectionStrings.Default = "DefaultConnection";
                o.ConnectionStrings.Add("Connection1", "ConnectionString1");
            });
        }
    }
}