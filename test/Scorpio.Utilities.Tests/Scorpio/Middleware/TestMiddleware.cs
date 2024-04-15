using System.Threading.Tasks;

using Scorpio.Middleware.Pipeline;

namespace Scorpio.Middleware
{
    public class TestMiddleware
    {
        private readonly PipelineRequestDelegate<TestPipelineContext> _next;

        public TestMiddleware(PipelineRequestDelegate<TestPipelineContext> next) => _next = next;
        public Task InvokeAsync(TestPipelineContext context)
        {
            context.PipelineInvoked = true;
            return _next(context);
        }
    }
}
