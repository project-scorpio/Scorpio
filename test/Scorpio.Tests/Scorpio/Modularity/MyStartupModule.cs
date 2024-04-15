namespace Scorpio.Modularity
{
    [DependsOn(typeof(IndependentEmptyModule))]
    public class MyStartupModule : ScorpioModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
        }
    }
}