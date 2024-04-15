using System.Threading.Tasks;

using Scorpio.Middleware.Pipeline;

namespace Scorpio.Middleware
{
    public class NonParameterMiddleware
    {
        private readonly PipelineRequestDelegate<TestPipelineContext> _next;

        public NonParameterMiddleware(PipelineRequestDelegate<TestPipelineContext> next) => _next = next;
        public Task InvokeAsync() => _next(null);
    }
}