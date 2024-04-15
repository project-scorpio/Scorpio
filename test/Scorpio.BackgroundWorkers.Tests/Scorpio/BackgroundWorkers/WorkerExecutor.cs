using System;

using Scorpio.DependencyInjection;

namespace Scorpio.BackgroundWorkers
{
    public class WorkerExecutor : ISingletonDependency
    {
        public Action<BackgroundWorkerContext> Action { get; set; }
    }
}