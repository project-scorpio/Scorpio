using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Scorpio.Threading;

namespace Scorpio.BackgroundWorkers
{
    public class FakeAsyncPeriodicBackgroundWorkerBase : AsyncPeriodicBackgroundWorkerBase
    {

        public IScorpioTimer ScorpioTimer => Timer;
        public FakeAsyncPeriodicBackgroundWorkerBase(IScorpioTimer timer, IServiceScopeFactory serviceScopeFactory) : base(timer, serviceScopeFactory)
        {
            timer.Period = 3600000;
            timer.RunOnStart = true;
        }

        protected override Task DoWorkAsync(BackgroundWorkerContext workerContext) => workerContext.ServiceProvider.GetService<AsyncWorkerExecutor>().ActionAsync(workerContext);
    }
}