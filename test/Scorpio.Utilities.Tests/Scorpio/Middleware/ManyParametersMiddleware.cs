using System;
using System.Threading.Tasks;

using Scorpio.Middleware.Pipeline;

namespace Scorpio.Middleware
{
    public class ManyParametersMiddleware
    {
        private readonly PipelineRequestDelegate<TestPipelineContext> _next;

        public ManyParametersMiddleware(PipelineRequestDelegate<TestPipelineContext> next) => _next = next;
        public Task InvokeAsync(TestPipelineContext context, IServiceProvider serviceProvider)
        {
            Check.NotNull(serviceProvider, nameof(serviceProvider));
            context.PipelineInvoked = true;
            return _next(context);
        }
    }
}