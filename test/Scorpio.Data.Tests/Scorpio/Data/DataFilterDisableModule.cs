using Microsoft.Extensions.DependencyInjection;

using Scorpio.Modularity;

namespace Scorpio.Data
{
    [DependsOn(typeof(DataModule))]
    public class DataFilterDisableModule : ScorpioModule
    {
        public override void ConfigureServices(ConfigureServicesContext context) => context.Services.Configure<DataFilterOptions>(options => DataFilterOptionsExtensions.Configure<ISoftDelete>(options, c => DataFilterDescriptorExtensions.Disable<ISoftDelete>(c)));
    }
}