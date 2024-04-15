using System;
using System.Threading.Tasks;

using Scorpio.DependencyInjection;

namespace Scorpio.BackgroundWorkers
{
    public class AsyncWorkerExecutor : ISingletonDependency
    {
        public Func<BackgroundWorkerContext, Task> ActionAsync { get; set; }
    }
}